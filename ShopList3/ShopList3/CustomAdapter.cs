using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ShopList3.Helper
{
    class CustomAdapter : BaseAdapter
    {
        private MainActivity mainActivity;
        private List<string> itemList;
        private DbHelper dbHelper;
        public CustomAdapter(MainActivity mainActivity, List<string> itemList, DbHelper dbHelper)
        {
            this.mainActivity = mainActivity;
            this.itemList = itemList;
            this.dbHelper = dbHelper;
        }
        public override int Count { get { return itemList.Count; } }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = (LayoutInflater)mainActivity.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.row, null);
            TextView txtTask = view.FindViewById<TextView>(Resource.Id.item_title);
            Button btnDelete = view.FindViewById<Button>(Resource.Id.btnDelete);
            txtTask.Text = itemList[position];
            btnDelete.Click += delegate
            {
                string task = itemList[position];
                dbHelper.deleteTask(task);
                mainActivity.LoadTaskList(); // Reload Data  
            };
            return view;
        }
    }
}