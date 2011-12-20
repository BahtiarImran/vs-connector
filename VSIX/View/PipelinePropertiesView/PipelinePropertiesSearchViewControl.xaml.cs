//
// Copyright © ThoughtWorks Studios 2010, 2011
//
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ThoughtWorksGoLib;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio.View.PipelinePropertiesView
{
    /// <summary>
    /// Interaction logic for PipelinePropertiesSearchViewControl.xaml
    /// </summary>
    public partial class PipelinePropertiesSearchViewControl : UserControl
    {
        internal GoPipelineSearchResultRow currentResultRow;

        /// <summary>
        /// Constructs a new PipelinePropertiesSearchViewControl
        /// </summary>
        internal PipelinePropertiesSearchViewControl()
        {
            InitializeComponent();
        }

        private void GoPropertiesSearchViewControlInitialized(object sender, EventArgs e)
        {
            TraceLog.WriteLine(new StackFrame().GetMethod().Name, "Entering...");
        }

        /// <summary>
        /// Binds Pipeline property search results to the view
        /// </summary>
        /// <param name="query">Object describing the search</param>
        internal void Bind(GoPipelineSearch query)
        {
            GoPipelineSearchResultSet results;

            try
            {
                results = query.Refresh();
            }
            catch (Exception e)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, e);
                MessageBox.Show(string.Format(@"{0}\r\n\nHost: {1}\r\nPipeline: {2}\r\nStage: {3}\r\nJob: {4}",
                                              VisualStudio.Resources.PipelineSearchError, query.Host,
                                              query.Pipeline, query.Stage, query.Job));
                return;
            }

            grid.Items.Clear();
            foreach (GoPipelineSearchResultRow result in results)
            {
                if (grid.Items.Add(result) >= 0)
                {
                    currentResultRow = result;
                    continue;
                }
                TraceLog.WriteLine(new StackFrame().GetMethod().Name,
                                   "Adding GoPropertiesSearchResult to grid object failed.");
                TraceLog.WriteLine(new StackFrame().GetMethod().Name,
                                   string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                                                 result.Agent, result.JobId,
                                                 result.JobDuration, result.JobResult,
                                                 result.PipelineLabel, result.PipelineLabel,
                                                 result.StageCounter,
                                                 result.Scheduled, result.Assigned,
                                                 result.Preparing, result.Building,
                                                 result.Completing, result.Completed));
                break;
            }
        }

        internal void GridLoadingRow(object sender, DataGridRowEventArgs e)
        {
            switch (((GoPipelineSearchResultRow) e.Row.Item).JobResult.ToUpper())
            {
                case "FAILED":
                    e.Row.Background = Brushes.LightCoral;
                    break;

                case "PASSED":
                    e.Row.Background = Brushes.LightGreen;
                    break;

                default:
                    e.Row.Background = Brushes.LightYellow;
                    break;
            }
        }
    }
}