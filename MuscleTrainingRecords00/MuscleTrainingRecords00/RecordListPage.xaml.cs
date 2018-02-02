using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MuscleTrainingRecords00;
using System.Windows.Input;

namespace MuscleTrainingRecords00
{
    public partial class RecordListPage : ContentPage
    {
        int m;
        public RecordListPage()
        {
            InitializeComponent();

           
        }


        //引っ張ったとき（更新）
        private async void OnRefreshing(object sender, EventArgs e)
        {
            // 1秒処理を待つ
            await Task.Delay(1000);

            //リフレッシュを止める
            list.IsRefreshing = false;

            InitializeComponent();

        }

        
        

        private void RecordListButton(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuPage());            
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Record r = (Record)(list.SelectedItem);
            string l = r.M_name;

            Record n =(Record)(list.SelectedItem);
             m = n.M_no;

            ReModelv2.key = m;
            Navigation.PushAsync(new RecordPage(l,m));

        }

        /*private void btnTest_Clicked(object sender, EventArgs e)
        {
            Record n = (Record)(list.SelectedItem);
            int m = n.M_no;
            RecordsModel.DeleteRecords(m);
        }*/

        async void OnDelete_Clicked(object sender, EventArgs args)
        {
            string no = ((DeleteButton)sender).NoText;
            string name = ((DeleteButton)sender).NameText;

            var result = await DisplayAlert("削除", "このメニューを削除しますか", "OK", "キャンセル");
            if (result == true)
            {
                int m_no = int.Parse(no);
                RecordsModel.DeleteRecords(m_no);

                InitializeComponent();
            }
        }
    }
}