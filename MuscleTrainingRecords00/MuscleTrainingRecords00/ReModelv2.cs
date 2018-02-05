using System;
using System.Collections.ObjectModel;
using SQLite;
namespace MuscleTrainingRecords00

{
    class ReModelv2
    {
        //public static int key;
        public static string name;
        //public static DateTime date;
        public ObservableCollection<Recordv2> Recordsv2
        {
            get;
            private set;

        }

        public ReModelv2()
        {
            //var query = RecordModelv2.SelectRe(key);
            var query = RecordModelv2.SelectRe(name); //前回　date
            if (query != null)
            //if (RecordModelv2.SelectRe(key) != null)
            //if(RecordModelv2.SelectRecord()!= null)
            {
                //var query = RecordModelv2.SelectRe(key);
                //var query = RecordModelv2.SelectRecord();
                Recordsv2 = new ObservableCollection<Recordv2>();

                foreach (var record in query)//拡張forループ
                {
                    Recordv2 r = new Recordv2
                    {
                        M_no = record.M_no,
                        M_name = record.M_name,
                        M_weight = record.M_weight,
                        M_leg = record.M_leg,
                        M_set = record.M_set,
                        M_date = record.M_date
                    };
                    //一行ずつ追加
                    Recordsv2.Add(r);
                }
            }

            /*if(RecoedsModel.SelectRecords())
            {

            }*/

            else
            {
                Recordsv2 = new ObservableCollection<Recordv2>
           {
               new Recordv2
               {
                   M_no=0,
                   M_name="データなし",
                   M_weight=0,
                   M_leg=0,
                   M_set=0,
                   M_date= new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day).ToString("yyyy/mm/dd"),

               }
           };
            }
        }
    }

    
    public class Recordv2
    {
        public int M_no { get; set; } //筋トレNo 主キー

        public string M_name { get; set; } //筋トレ名前

        public int M_weight { get; set; } //重量

        public int M_leg { get; set; } //回数

        public int M_set { get; set; } //セット数

        public string M_date { get; set; } //日

    }


}
