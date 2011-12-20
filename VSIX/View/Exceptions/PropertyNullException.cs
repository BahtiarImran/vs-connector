//
// Copyright © 2010, 2011 ThoughtWorks, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at:
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
//

using System;
using System.Runtime.Serialization;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// This exception is used to notify that a required property is null
    /// </summary>
    [Serializable]
    public class PropertyNullException : Exception
    {
        /// <summary>
        /// Creates a PropertyNullException
        /// </summary>
        public PropertyNullException()
        {
        }

        /// <summary>
        /// Creates a PropertyNullException
        /// </summary>
        /// <param name="message">Message for the exception</param>
        public PropertyNullException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a PropertyNullException
        /// </summary>
        /// <param name="message">Message for the exception</param>
        /// <param name="inner">Exception that triggered this exception</param>
        public PropertyNullException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Creates a PropertyNullException
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        protected PropertyNullException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
