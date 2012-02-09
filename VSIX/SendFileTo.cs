using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ThoughtWorks.VisualStudio
{
    internal class Mapi
    {
        internal bool AddRecipientTo(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        internal bool AddRecipientCc(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        internal bool AddRecipientBcc(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        internal void AddAttachment(string strAttachmentFileName)
        {
            m_attachments.Add(strAttachmentFileName);
        }

        internal int SendMailPopup(string strSubject, string strBody)
        {
            return SendMail(strSubject, strBody, MAPI_LOGON_UI | MAPI_DIALOG);
        }

        internal int SendMailDirect(string strSubject, string strBody)
        {
            return SendMail(strSubject, strBody, MAPI_LOGON_UI);
        }


        [SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments",
            MessageId = "MapiMessage.subject"),
         SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments",
             MessageId = "MapiMessage.noteText"),
         SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments",
             MessageId = "MapiMessage.messageType"),
         SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments",
             MessageId = "MapiMessage.dateReceived"),
         SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments",
             MessageId = "MapiMessage.conversationID"),
         SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("MAPI32.DLL")]
        private static extern int MAPISendMail(IntPtr sess, IntPtr hwnd, MapiMessage message, int flg, int rsv);

        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions"),
         SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "MAPISendMail"),
         SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
             MessageId = "System.Windows.Forms.MessageBox.Show(System.String,System.String)")]
        private int SendMail(string strSubject, string strBody, int how)
        {
            var msg = new MapiMessage();
            msg.subject = strSubject;
            msg.noteText = strBody;

            msg.recips = GetRecipients(out msg.recipCount);
            msg.files = GetAttachments(out msg.fileCount);

            m_lastError = MAPISendMail(new IntPtr(0), new IntPtr(0), msg, how, 0);
            if (m_lastError > 1)
                MessageBox.Show("MAPISendMail failed! " + GetLastError(), "MAPISendMail");

            Cleanup(ref msg);
            return m_lastError;
        }

        private bool AddRecipient(string email, HowTo howTo)
        {
            var recipient = new MapiRecipDesc();

            recipient.recipClass = (int) howTo;
            recipient.name = email;
            m_recipients.Add(recipient);

            return true;
        }

        private IntPtr GetRecipients(out int recipCount)
        {
            recipCount = 0;
            if (m_recipients.Count == 0)
                return IntPtr.Zero;

            int size = Marshal.SizeOf(typeof (MapiRecipDesc));
            IntPtr intPtr = Marshal.AllocHGlobal(m_recipients.Count*size);

            var ptr = (int) intPtr;
            foreach (MapiRecipDesc mapiDesc in m_recipients)
            {
                Marshal.StructureToPtr(mapiDesc, (IntPtr) ptr, false);
                ptr += size;
            }

            recipCount = m_recipients.Count;
            return intPtr;
        }

        private IntPtr GetAttachments(out int fileCount)
        {
            fileCount = 0;
            if (m_attachments == null)
                return IntPtr.Zero;

            if ((m_attachments.Count <= 0) || (m_attachments.Count > maxAttachments))
                return IntPtr.Zero;

            int size = Marshal.SizeOf(typeof (MapiFileDesc));
            IntPtr intPtr = Marshal.AllocHGlobal(m_attachments.Count*size);

            var mapiFileDesc = new MapiFileDesc();
            mapiFileDesc.position = -1;
            var ptr = (int) intPtr;

            foreach (string strAttachment in m_attachments)
            {
                mapiFileDesc.name = Path.GetFileName(strAttachment);
                mapiFileDesc.path = strAttachment;
                Marshal.StructureToPtr(mapiFileDesc, (IntPtr) ptr, false);
                ptr += size;
            }

            fileCount = m_attachments.Count;
            return intPtr;
        }

        private void Cleanup(ref MapiMessage msg)
        {
            int size = Marshal.SizeOf(typeof (MapiRecipDesc));
            int ptr = 0;

            if (msg.recips != IntPtr.Zero)
            {
                ptr = (int) msg.recips;
                for (int i = 0; i < msg.recipCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr) ptr, typeof (MapiRecipDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.recips);
            }

            if (msg.files != IntPtr.Zero)
            {
                size = Marshal.SizeOf(typeof (MapiFileDesc));

                ptr = (int) msg.files;
                for (int i = 0; i < msg.fileCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr) ptr, typeof (MapiFileDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.files);
            }

            m_recipients.Clear();
            m_attachments.Clear();
            m_lastError = 0;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.ToString"
            )]
        internal string GetLastError()
        {
            if (m_lastError <= 26)
                return errors[m_lastError];
            return "MAPI error [" + m_lastError.ToString() + "]";
        }

        private readonly string[] errors = new[]
                                               {
                                                   "OK [0]", "User abort [1]", "General MAPI failure [2]",
                                                   "MAPI login failure [3]",
                                                   "Disk full [4]", "Insufficient memory [5]", "Access denied [6]",
                                                   "-unknown- [7]",
                                                   "Too many sessions [8]", "Too many files were specified [9]",
                                                   "Too many recipients were specified [10]",
                                                   "A specified attachment was not found [11]",
                                                   "Attachment open failure [12]", "Attachment write failure [13]",
                                                   "Unknown recipient [14]", "Bad recipient type [15]",
                                                   "No messages [16]", "Invalid message [17]", "Text too large [18]",
                                                   "Invalid session [19]",
                                                   "Type not supported [20]",
                                                   "A recipient was specified ambiguously [21]", "Message in use [22]",
                                                   "Network failure [23]",
                                                   "Invalid edit fields [24]", "Invalid recipients [25]",
                                                   "Not supported [26]"
                                               };


        private readonly List<MapiRecipDesc> m_recipients = new List<MapiRecipDesc>();
        private readonly List<string> m_attachments = new List<string>();
        private int m_lastError;

        private const int MAPI_LOGON_UI = 0x00000001;
        private const int MAPI_DIALOG = 0x00000008;
        private const int maxAttachments = 20;

        private enum HowTo
        {
            MAPI_ORIG = 0,
            MAPI_TO,
            MAPI_CC,
            MAPI_BCC
        };
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class MapiMessage
    {
        internal int reserved;
        internal string subject;
        internal string noteText;
        internal string messageType;
        internal string dateReceived;
        internal string conversationID;
        internal int flags;
        internal IntPtr originator;
        internal int recipCount;
        internal IntPtr recips;
        internal int fileCount;
        internal IntPtr files;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class MapiFileDesc
    {
        internal int reserved;
        internal int flags;
        internal int position;
        internal string path;
        internal string name;
        internal IntPtr type;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal class MapiRecipDesc
    {
        internal int reserved;
        internal int recipClass;
        internal string name;
        internal string address;
        internal int eIDSize;
        internal IntPtr entryID;
    }
}