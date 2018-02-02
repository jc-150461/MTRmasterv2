using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuscleTrainingRecords00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteButton : ContentView
    {
        public static readonly BindableProperty NoTextProperty =
          BindableProperty.Create(
              "NoText",
              typeof(string),
              typeof(DeleteButton),
              null,
              propertyChanged: (bindable, oldValue, newValue) =>
              {
                  ((DeleteButton)bindable).textNoLabel.Text = (string)newValue;
              });


        public static readonly BindableProperty NameTextProperty =
           BindableProperty.Create(
               "NameText",
               typeof(string),
               typeof(DeleteButton),
               null,
               propertyChanged: (bindable, oldValue, newValue) =>
               {
                   ((DeleteButton)bindable).textNameLabel.Text = (string)newValue;
               });

        /*public static readonly BindableProperty IsCheckedProperty =
          BindableProperty.Create(
              "IsChecked",
              typeof(bool),
              typeof(DeleteButton),
              false,
              propertyChanged: (bindable, oldValue, newValue) =>
              {
                  DeleteButton button = (DeleteButton)bindable;

                   //イベント発行
                   EventHandler<bool> eventHandler = button.CheckedChanged;
                  if (eventHandler != null)
                  {
                      eventHandler(button, (bool)newValue);
                  }
              });*/

        public event EventHandler<bool> CheckedChanged;

        public DeleteButton()
        {
            InitializeComponent();
        }

        public string NoText
        {
            set { SetValue(NoTextProperty, value); }
            get { return (string)GetValue(NoTextProperty); }
        }

        public string NameText
        {
            set { SetValue(NameTextProperty, value); }
            get { return (string)GetValue(NameTextProperty); }
        }

        //TapGestureRecognizerハンドラー
       /* void OnButtonTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
        }*/

    }
}