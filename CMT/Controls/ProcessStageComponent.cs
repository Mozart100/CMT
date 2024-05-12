using System.Windows.Controls;
using System.Windows;
using System.Text.RegularExpressions;
using System;

namespace CMT.Controls;

public enum ProcessStage
{
    Stage1=1,
    Stage2=2,
    Stage3=3,
    Stage4=4,
    Stage5=5
}

public class ProcessStageHelper : DependencyObject
{
    public static void SetProcessCompletion(ProgressBar bar, double progress)
    {
        bar.SetValue(ProcessCompletionProperty, progress);
    }

    public static void SetProcessStage(ProgressBar bar, ProcessStage stage)
    {
        bar.SetValue(ProcessStagePropertyKey, stage);
    }

    public static readonly DependencyProperty ProcessCompletionProperty = DependencyProperty.RegisterAttached("ProcessCompletion", typeof(double), typeof(ProcessStageHelper), new PropertyMetadata(0.0, OnProcessCompletionChanged));

    private static readonly DependencyPropertyKey ProcessStagePropertyKey = DependencyProperty.RegisterAttachedReadOnly("ProcessStage", typeof(ProcessStage), typeof(ProcessStageHelper), new PropertyMetadata(ProcessStage.Stage1));

    public static readonly DependencyProperty ProcessStageProperty = ProcessStagePropertyKey.DependencyProperty;

    private static void OnProcessCompletionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var progress = (double)e.NewValue;

        if (d is ProgressBar progressBar)
        {
            var stage = progress / 20;

            if (stage <= 1)
            {
                progressBar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage1);
                return;
            }

            if (stage <= 2)
            {
                progressBar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage2);
                return;
            }

            if (stage <= 3)
            {
                progressBar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage3);
                return;
            }

            if (stage <= 4)
            {
                progressBar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage4);
                return;
            }

            progressBar.SetValue(ProcessStagePropertyKey, ProcessStage.Stage5);
        }
    }

  
}
