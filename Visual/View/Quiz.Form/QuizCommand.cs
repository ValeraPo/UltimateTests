using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Visual.Command;

namespace Visual.View.Quiz.Form
{
    //public class NextCommandClicked : CommandBase
    //{
    //    private QuizViewModel _viewModel;

    //    public NextCommandClicked(QuizViewModel viewModel) : base()
    //    {
    //        _viewModel = viewModel;
    //    }
    //    public override void Execute(object parameter)
    //    {
    //        _viewModel.QuizIndex++;
    //        _viewModel.CurrentQuestion = _viewModel.QurrentQuiz.Questions.ElementAt(_viewModel.QuizIndex);
    //        SetAnswerGrid(_viewModel.CurrentQuestion);



    //    }
    //    public void SetAnswerGrid(QuestionDTO question)
    //    {
    //        switch (question.ID_QuestType)
    //        {
    //            case 1:

    //                //


    //                break;
    //            case 2:
    //                _viewModel.VisabilitystackPanelRadioButtons = Visibility.Hidden;
    //                _viewModel.VisabilityStackPanelCheckBox = Visibility.Visible;
    //                _viewModel.VisabilityFreeAnswerTextBlock = Visibility.Hidden;
    //                break;
    //            default:
    //                _viewModel.VisabilitystackPanelRadioButtons = Visibility.Hidden;
    //                _viewModel.VisabilityStackPanelCheckBox = Visibility.Hidden;
    //                _viewModel.VisabilityFreeAnswerTextBlock = Visibility.Visible;
    //                break;
    //        }
    //    }
    //    public void SetAnswers()
    //    {

    //    }
    //}
}
