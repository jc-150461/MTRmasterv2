﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuscleTrainingRecords00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {


        public GraphPage()
        {
            InitializeComponent();

            today.Text = DateTime.Today.ToString("yyyy/MM/dd");


        }
        //DateTime yyyymmdd;//追加







        /********************ここから追加******************************************/

        async Task Handle_ClickedAsync(object sender, System.EventArgs e)
        {

            try
            {
                var db = TodoItemDatabase.getDatabase();
                double B_Weight = int.Parse(bWeight.Text);
                double B_Fat = int.Parse(bFat.Text);
                DateTime dCreated = DateTime.Today;


                TodoItem sameDateItem = await db.GetItemByCreatedAsync(dCreated);
                if (sameDateItem == null)
                {
                    TodoItem item = new TodoItem() { Created = dCreated, Bweight = B_Weight, Bfat = B_Fat };
                    await db.SaveItemAsync(item);
                    await DisplayAlert("", "記録されました:" + item.Created.ToString("yyyy/MM/dd"), "OK");
                }

                else
                {
                    await db.DeleteItemAsync(sameDateItem);
                    TodoItem item = new TodoItem() { Created = dCreated, Bweight = B_Weight, Bfat = B_Fat };
                    await db.SaveItemAsync(item);
                    await DisplayAlert("", "更新されました:{" + sameDateItem.Created.ToString("yyyy/MM/dd") + "}→{" + item.Created.ToString("yyyy/MM/dd") + "}", "OK");

                }

                Application.Current.MainPage = new MainPage();
            }
            catch (Exception)
            {
                await DisplayAlert("", "数値を入力してください", "OK");
            }
        }
    }
}

