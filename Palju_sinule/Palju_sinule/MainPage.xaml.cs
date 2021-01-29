using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Palju_sinule
{
    public partial class MainPage : ContentPage
    {
        List<string> BFF, mail, number, GR;
        public MainPage()
        {
            BFF = new List<string>() { "Андрей","Дима","Алекс","Иван","Марк","Максим","Влад" };
            number = new List<string>() { "5300331", "400221", "843023","568934","438893","342908","291837" };
            mail = new List<string> { "Andre12@gmail.com", "D1mas@gmail.com", "aleksas4@gmail.com","Ivasaj@gmail.com","Markiiii@gmail.com","Maksimu9@gmail.com","HaCkEr228_Vlad@gmail.com" };
            GR = new List<string> { "С новым годом!", "Удачного провести каникулы!", "С счастьем в новом году!", "С наступающим!", "Счастья, здоровья и МНОГО денеггг!" };
            InitializeComponent();
            friendPicker.ItemsSource = BFF;
            friendPicker.SelectedIndexChanged += FriendPicker_SelectedIndexChanged;
            pozd.Clicked += pozd_Clicked;
        }

        private async void pozd_Clicked(object sender, EventArgs e)
        {
            Random ranGreet = new Random();
            int rand = ranGreet.Next(5);
            if (type.IsToggled == true)
            {
                await Sms.ComposeAsync(new SmsMessage { Body = GR[rand], Recipients = new List<string> { number[friendPicker.SelectedIndex] } });
            }
            else
            {
                await Email.ComposeAsync("Поздравление", GR[rand], mail[friendPicker.SelectedIndex]);
            }

        }
        private void FriendPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            maill.Text = mail[friendPicker.SelectedIndex];
            num.Text = number[friendPicker.SelectedIndex];
        }
    }
}
