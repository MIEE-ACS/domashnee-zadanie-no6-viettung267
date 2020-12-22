using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TUNGDZ6
{
    public partial class MainWindow : Window
    {
        abstract class Weapons
        {
            public class WeaponException : Exception
            {
                public WeaponException(string message)
                    : base(message)
                { }
            }
            public override string ToString()
            {
                return "Оружие, ";
            }
        }

        class Cold : Weapons
        {
            public override string ToString()
            {
                return base.ToString() + "Холодное";
            }
        }

        class Firearms : Weapons
        {
            public override string ToString()
            {
                return base.ToString() + "Огнестрельное";
            }
        }

        class Thermonuclear : Weapons
        {
            public override string ToString()
            {
                return base.ToString() + "Термоядерное";
            }
        }
        class Crossbow : Cold
        {
            int radius;
            int rate;
            int speed;
            public int Radius
            {
                get { return radius; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("RadiusException");
                    radius = value;
                }
            }
            public int Rate
            {
                get { return rate; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("RateException");
                    rate = value;
                }
            }
            public int Speed
            {
                get { return speed; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("SpeedException");
                    speed = value;
                }
            }
            public override string ToString()
            {
                return base.ToString() + $" Арбалет  Радиус поражения: {Radius}  Скорострельность: {Rate}  Скорость перезарядки: {Speed}";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                Crossbow w = obj as Crossbow;
                return Radius.Equals(w.Radius) && Rate.Equals(w.Rate) && Speed.Equals(w.Speed);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
        class Auto : Firearms
        {
            int radius;
            int rate;
            int speed;
            public int Radius
            {
                get { return radius; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("RadiusException");
                    radius = value;
                }
            }
            public int Rate
            {
                get { return rate; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("RateException");
                    rate = value;
                }
            }
            public int Speed
            {
                get { return speed; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("SpeedException");
                    speed = value;
                }
            }
            public override string ToString()
            {
                return base.ToString() + $" Автомат  Радиус поражения: {Radius}  Скорострельность: {Rate}  Скорость перезарядки: {Speed}";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                Auto w = obj as Auto;
                return Radius.Equals(w.Radius) && Rate.Equals(w.Rate) && Speed.Equals(w.Speed);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
        class MBR : Thermonuclear
        {
            int radius;
            int rate;
            int speed;
            public int Radius
            {
                get { return radius; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("RadiusException");
                    radius = value;
                }
            }
            public int Rate
            {
                get { return rate; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("RateException");
                    rate = value;
                }
            }
            public int Speed
            {
                get { return speed; }
                set
                {
                    if (value <= 0)
                        throw new WeaponException("SpeedException");
                    speed = value;
                }
            }
            public override string ToString()
            {
                return base.ToString() + $" МБР  Радиус поражения: {Radius}  Скорострельность: {Rate}  Скорость перезарядки: {Speed}";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                MBR w = obj as MBR;
                return Radius.Equals(w.Radius) && Rate.Equals(w.Rate) && Speed.Equals(w.Speed);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        List<string> data=new List<string>();
        string[] s=new string[15];
        int click=0;
        int[] radiuscategory = new int[15];

        public MainWindow()
        {
            InitializeComponent();
        }

        public bool delete()
        {
            bool check = true;
            if (click >= 1)
            {
                for (int i = 0; i < click; i++)
                {
                    if (s[click] == s[i])
                    {
                        check = false;
                    }
                }
            }
            return check;
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            int choose = CB_Weapons.SelectedIndex;
            switch(choose)
            {
                case 0:
                    {
                        Crossbow crossbow = new Crossbow();
                        crossbow.Radius = int.Parse(dam_radius.Text);
                        crossbow.Rate = int.Parse(Rate_fire.Text);
                        crossbow.Speed = int.Parse(Re_speed.Text);
                        s[click] = crossbow.ToString();
                        if (delete()==true)
                        {
                            radiuscategory[click] = crossbow.Radius;
                            data.Add(crossbow.ToString());
                            Listresult.ItemsSource = data;
                            Listresult.Items.Refresh();
                            click++;
                        }
                        break;
                    }
                case 1:
                    {
                        Auto auto = new Auto();
                        auto.Radius = int.Parse(dam_radius.Text);
                        auto.Rate = int.Parse(Rate_fire.Text);
                        auto.Speed = int.Parse(Re_speed.Text);
                        s[click] = auto.ToString();
                        if (delete() == true)
                        {
                            radiuscategory[click] = auto.Radius;
                            data.Add(auto.ToString());
                            Listresult.ItemsSource = data;
                            Listresult.Items.Refresh();
                            click++;
                        }
                        break;
                    }
                case 2:
                    {
                        MBR mbr = new MBR();
                        mbr.Radius = int.Parse(dam_radius.Text);
                        mbr.Rate = int.Parse(Rate_fire.Text);
                        mbr.Speed = int.Parse(Re_speed.Text);
                        s[click] = mbr.ToString();
                        if (delete() == true)
                        {
                            radiuscategory[click] = mbr.Radius;
                            data.Add(mbr.ToString());
                            Listresult.ItemsSource = data;
                            Listresult.Items.Refresh();
                            click++;
                        }
                        break;
                    }
            }
        }

        private void searchbt_Click(object sender, RoutedEventArgs e)
        {
            int choose = cbcategory.SelectedIndex;
            List<string> Listsearch = new List<string>();
            switch (choose)
            {
                case 0:
                    {
                        int radiusip = int.Parse(tbfind.Text);
                        for (int i = 0; i < click; i++)
                        {
                            if (radiuscategory[i]>=radiusip)
                            {
                                Listsearch.Add(s[i]);
                                Listresult.ItemsSource = Listsearch;
                                Listresult.Items.Refresh();
                            }
                        }
                       
                        break;
                    }
                case 1:
                    {
                        string typeweapon = Typeweapons.Text;
                        for (int i=0; i<click;i++)
                        {
                            if (typeweapon[0] == s[i][8])
                            {
                                Listsearch.Add(s[i]);
                                Listresult.ItemsSource = Listsearch;
                                Listresult.Items.Refresh();
                            }
                        }                       
                        break;
                    }
            }
        }

        private void cbcategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int choose = cbcategory.SelectedIndex;
            switch(choose)
            {
                case 0:
                    {
                        tbfind.Visibility = Visibility.Visible;
                        Typeweapons.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        tbfind.Visibility = Visibility.Hidden;
                        Typeweapons.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }

        private void Showbt_Click(object sender, RoutedEventArgs e)
        {
            Listresult.ItemsSource = data;
            Listresult.Items.Refresh();
        }
    }
}
