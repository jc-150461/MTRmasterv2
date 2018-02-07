﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MuscleTrainingRecords00;

namespace MuscleTrainingRecords00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordPage : ContentPage
    {
        int t;
        string x;
        public RecordPage(string l, int m)//string l
        {
            InitializeComponent();

            m_name.Text = l;

            x = l;
            t = m;


            ToolbarItem tItem = new ToolbarItem
            {
                Icon = "ic_delete.png",
                Text = "メニュー削除",
                Priority = 1,
                Order = ToolbarItemOrder.Primary,
                Command = new Command(async () =>
                {





                    bool result = await DisplayAlert("削除", "このメニューを削除しますか", "OK", "キャンセル");

                    if (result == true)
                    {
                        int no = m;

                        int M_no = no;

                        RecordsModel.DeleteRecords(M_no);

                        InitializeComponent();

                        await Navigation.PushAsync(new RecordListPage());
                    }
                }),


            };
            this.ToolbarItems.Add(tItem);

        }

        /* protected override void OnAppearing()
         {
             DisplayAlert("id", ReModelv2.key+" " + ReModelv2.name +" "+ReModelv2.date, "OK");
         }*/


        //引っ張ったとき（更新）
        private async void OnRefreshing(object sender, EventArgs e)
        {
            // 1秒処理を待つ
            await Task.Delay(1000);

            //リフレッシュを止める
            list.IsRefreshing = false;

            InitializeComponent();

            m_name.Text = x;

        }

        private async Task addItemButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Weight.Text == null || Reps.Text == null || Set.Text == null)
                {
                    DisplayAlert("", "入力が不足しています", "OK");
                }
            }catch(Exception)
            {
                DisplayAlert("", "入力してください。", "OK");
            }

            int WeightText = int.Parse(Weight.Text);
            int RepsText = int.Parse(Reps.Text);
            int SetText = int.Parse(Set.Text);

            bool result = await DisplayAlert("保存", WeightText+"kg "+ RepsText+"回数 "+SetText
                     +"セット を保存しますか", "OK", "キャンセル");

            if (result == true)
            {
                DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                string date = now.ToString("yyyy/MM/dd");

                RecordModelv2.InsertRe(t, x, WeightText, RepsText, SetText, date);

                InitializeComponent();

            }  
        }

        private async Task list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Recordv2 n = (Recordv2)(list.SelectedItem);
            int m = n.M_no;


            bool result = await DisplayAlert("削除", "この記録を削除しますか", "OK", "キャンセル");

            if (result == true)
            {
                int no = m;

                int M_no = no;

                RecordModelv2.DeleteRecords(M_no);

                InitializeComponent();

                m_name.Text = x;

            }
        }
    }
}
