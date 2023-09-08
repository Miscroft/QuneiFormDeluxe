using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using static System.Net.Mime.MediaTypeNames;

namespace QuneiForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _istrue = false;
        private List<string> _mudblock = new List<string>();
        public class Zipbag
        {
            public int PRICE = 0;
            public Point DRUG;
            public Point MEDICINE;
        }
        private List<Zipbag> _zipbag = new List<Zipbag>();
        private int _pinposition = 0;
        private int _zipbagposition = 0;
        private List<Zipbag> _account = new List<Zipbag>();
        private List<string> _zipbagtocypher = new List<string>();
        private string _zipbagcyphered = "";
        public MainWindow()
        {
            InitializeComponent();
            _zipbag.Add(new Zipbag());
            _zipbag.Add(new Zipbag());
            _zipbag.Add(new Zipbag());
            _zipbag.Add(new Zipbag());
            _account.Add(new Zipbag());
            _account.Add(new Zipbag());
            DealerMessage.AppendText("QuneiForm線上交易系統連線中...");
        }
        #region 指令集
        private void Upper_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("👆");
        }

        private void Lower_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("👇");
        }

        private void First_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("👈");
        }

        private void Last_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("👉");
        }

        private void Clear_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("🆑");
        }

        private void How_much_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("🙏");
        }

        private void cypher_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("🤛");
        }
        private void Deal_failed_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("⚔");
        }

        private void Pay_1_buck_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("➀");
        }

        private void Pay_5_buck_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("➄");
        }

        private void Pay_10_buck_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("➉");
        }

        private void Pay_50_buck_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("㊿");
        }

        private void Pay_100_buck_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("Ⓒ");
        }

        private void Accept_1_buck_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("一");
        }

        private void Accept_5_buck(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("五");
        }

        private void Accept_10_buck(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("十");
        }

        private void Accept_50_buck(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("圩");
        }

        private void Accept_100_buck(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("百");
        }

        private void Zipperbag1(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("㈠");
        }

        private void Repay1(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("㍙");
        }

        private void Zipperbag2(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("㈡");
        }

        private void Repay2(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("㍚");
        }

        private void Heavier_than(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("⤴");
        }

        private void Lighter_than(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("⤵");
        }

        private void Equal_to(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("⚖");
        }

        private void If_true(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("㊒");
        }

        private void Shopping_list(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("📝");
        }

        private void Check_list(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("🧾");
        }

        private void Weed(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("🍁");
        }

        private void Shroom(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("🍄");
        }

        private void Capsule(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("💊");
        }

        private void Pill(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("⛔");
        }

        private void Syringe(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("💉");
        }

        private void Stiring(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("🥣");
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("➕");
        }

        private void Multiply(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("✖️");
        }

        private void Devided_by(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("➗");
        }
        private void More(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("📦");
        }
        private void Pin_click(object sender, RoutedEventArgs e)
        {
            MudBlock.AppendText("📌");
        }
        #endregion

        private void Wallet_click(object sender, RoutedEventArgs e)
        {
            if(_mudblock.Count == 0)
            {
                TextRange textRange = new TextRange( MudBlock.Document.ContentStart, MudBlock.Document.ContentEnd );
                var info = new StringInfo(textRange.Text);
                var realLength = info.LengthInTextElements;
                for (int i = 0; i < realLength; i++)
                    _mudblock.Add(StringInfo.GetNextTextElement(textRange.Text, i));
            }
            for (int i_mudblock = 0; i_mudblock < _mudblock.Count; i_mudblock++)
            {
                if (_mudblock[i_mudblock] == "📦")
                {
                    _zipbag.Add(new Zipbag());
                    _zipbag.Add(new Zipbag());
                    _zipbag.Add(new Zipbag());
                    _zipbag.Add(new Zipbag());
                }
                else if (_mudblock[i_mudblock] == "⚔")
                {
                    _zipbag = new List<Zipbag>
                    {
                        new Zipbag(),
                        new Zipbag(),
                        new Zipbag(),
                        new Zipbag()
                    };
                    _zipbagposition = 0;
                }
                else if (_mudblock[i_mudblock] == "🆑")
                {
                    _zipbag[_zipbagposition] = new Zipbag();
                }
                else if (_mudblock[i_mudblock] == "👆")
                {
                    if(_zipbagposition > 0) { _zipbagposition--; }
                }
                else if (_mudblock[i_mudblock] == "👇")
                {
                    if (_zipbagposition < _zipbag.Count - 1) { _zipbagposition++; }
                }
                else if (_mudblock[i_mudblock] == "👈")
                {
                    _zipbagposition = 0;
                }
                else if (_mudblock[i_mudblock] == "👉")
                {
                    _zipbagposition = _zipbag.Count - 1;
                }
                else if (_mudblock[i_mudblock] == "➀")
                {
                    _zipbag[_zipbagposition].PRICE += 1;
                }
                else if (_mudblock[i_mudblock] == "➄")
                {
                    _zipbag[_zipbagposition].PRICE += 5;
                }
                else if (_mudblock[i_mudblock] == "➉")
                {
                    _zipbag[_zipbagposition].PRICE += 10;
                }
                else if (_mudblock[i_mudblock] == "㊿")
                {
                    _zipbag[_zipbagposition].PRICE += 50;
                }
                else if (_mudblock[i_mudblock] == "Ⓒ")
                {
                    _zipbag[_zipbagposition].PRICE += 100;
                }
                else if (_mudblock[i_mudblock] == "一")
                {
                    _zipbag[_zipbagposition].PRICE -= 1;
                }
                else if (_mudblock[i_mudblock] == "五")
                {
                    _zipbag[_zipbagposition].PRICE -= 5;
                }
                else if (_mudblock[i_mudblock] == "十")
                {
                    _zipbag[_zipbagposition].PRICE -= 10;
                }
                else if (_mudblock[i_mudblock] == "圩")
                {
                    _zipbag[_zipbagposition].PRICE -= 50;
                }
                else if (_mudblock[i_mudblock] == "百")
                {
                    _zipbag[_zipbagposition].PRICE -= 100;
                }
                else if (_mudblock[i_mudblock] == "㈠")
                {
                    _account[0] = _zipbag[_zipbagposition];
                }
                else if (_mudblock[i_mudblock] == "㈡")
                {
                    _account[1] = _zipbag[_zipbagposition];
                }
                else if (_mudblock[i_mudblock] == "⤴")
                {
                    if (_account[1].PRICE > _zipbag[_zipbagposition].PRICE)
                    { _istrue = true; }
                    else { _istrue = false; }
                }
                else if (_mudblock[i_mudblock] == "⤵")
                {
                    if (_account[1].PRICE < _zipbag[_zipbagposition].PRICE)
                    { _istrue = true; }
                    else { _istrue = false; }
                }
                else if (_mudblock[i_mudblock] == "⚖")
                {
                    if (_account[1].PRICE == _zipbag[_zipbagposition].PRICE)
                    { _istrue = true; }
                    else { _istrue = false; }
                }
                else if (_mudblock[i_mudblock] == "㊒")
                {
                    if(_istrue == true)
                        i_mudblock = _pinposition;
                    _istrue = false;
                }
                else if (_mudblock[i_mudblock] == "📌")
                {
                    _pinposition = i_mudblock;
                }
                else if (_mudblock[i_mudblock] == "🍁")
                {
                    double _drug = 0.0;
                    string _test = "";
                    int i_test = i_mudblock + 2;
                    for(; _mudblock[i_test] != "🍁" && i_test < _mudblock.Count - 1; i_test++)
                    {
                        _test += _mudblock[i_test];
                    }
                    if (i_test == _mudblock.Count) return;
                    else i_mudblock = i_test;

                    if (Double.TryParse(_test, out _drug))
                    _zipbag[_zipbagposition].DRUG.X = _drug;
                }
                else if (_mudblock[i_mudblock] == "🍄")
                {
                    double _drug = 0.0;
                    string _test = "";
                    int i_test = i_mudblock + 2;
                    for (; _mudblock[i_test] != "🍄" && i_test < _mudblock.Count - 1; i_test++)
                    {
                        _test += _mudblock[i_test];
                    }
                    if (i_test == _mudblock.Count) return;
                    else i_mudblock = i_test;

                    if (Double.TryParse(_test, out _drug))
                        _zipbag[_zipbagposition].DRUG.Y = _drug;
                }
                else if (_mudblock[i_mudblock] == "💊")
                {
                    double _drug = 0.0;
                    string _test = "";
                    int i_test = i_mudblock + 2;
                    for (; _mudblock[i_test] != "💊" && i_test < _mudblock.Count - 1; i_test++)
                    {
                        _test += _mudblock[i_test];
                    }
                    if (i_test == _mudblock.Count) return;
                    else i_mudblock = i_test;

                    if (Double.TryParse(_test, out _drug))
                        _zipbag[_zipbagposition].MEDICINE.X = _drug;
                }
                else if (_mudblock[i_mudblock] == "⛔")
                {
                    double _drug = 0.0;
                    string _test = "";
                    int i_test = i_mudblock + 2;
                    for (; _mudblock[i_test] != "⛔" && i_test < _mudblock.Count - 1; i_test++)
                    {
                        _test += _mudblock[i_test];
                    }
                    if (i_test == _mudblock.Count) return;
                    else i_mudblock = i_test;

                    if (Double.TryParse(_test, out _drug))
                        _zipbag[_zipbagposition].MEDICINE.Y = _drug;
                }
                else if (_mudblock[i_mudblock] == "➕")
                {
                    _zipbag[_zipbagposition].DRUG.X = _account[0].DRUG.X + _account[1].DRUG.X;
                    _zipbag[_zipbagposition].DRUG.Y = _account[0].DRUG.Y + _account[1].DRUG.Y;
                }
                else if (_mudblock[i_mudblock] == "✖️")
                {
                    _zipbag[_zipbagposition].DRUG.X = _account[0].DRUG.X * _account[1].DRUG.X - _account[0].DRUG.Y * _account[1].DRUG.Y;
                    _zipbag[_zipbagposition].DRUG.Y = _account[0].DRUG.Y * _account[1].DRUG.X + _account[1].DRUG.Y * _account[0].DRUG.X;
                }
                else if (_mudblock[i_mudblock] == "➗")
                {
                    double dem = _account[1].DRUG.X * _account[1].DRUG.X + _account[1].DRUG.Y * _account[1].DRUG.Y;
                    if (Math.Abs(dem) > 1e-8)
                    {
                        _zipbag[_zipbagposition].DRUG.X = (_account[0].DRUG.X * _account[1].DRUG.X + _account[0].DRUG.Y * _account[1].DRUG.Y) / dem;
                        _zipbag[_zipbagposition].DRUG.Y = (_account[0].DRUG.Y * _account[1].DRUG.X - _account[0].DRUG.X * _account[1].DRUG.Y) / dem;
                    }
                    else
                    {
                        _zipbag[_zipbagposition].DRUG.X = 0; _zipbag[_zipbagposition].DRUG.Y = 0;
                    }
                }
                else if (_mudblock[i_mudblock] == "💉")
                {

                }
                else if (_mudblock[i_mudblock] == "🥣")
                {

                }
                else if (_mudblock[i_mudblock] == "📝")
                {

                }
                else if (_mudblock[i_mudblock] == "🧾")
                {

                }
                else if (_mudblock[i_mudblock] == "🤛")
                {
                    foreach (var bag in _zipbagcyphered)
                    {
                        _mudblock.Add(bag.ToString());
                    }
                }
            }
            _zipbagtocypher = new List<string>();
            foreach(var bag in _zipbag)
            {
                int bagPRICE = bag.PRICE;
                if(bagPRICE < 0) bagPRICE *= -1;
                bagPRICE = bagPRICE % 256;
                _zipbagtocypher.Add(Convert.ToString(bagPRICE, 16));
            }

            _zipbagcyphered = "";
            for (int i_cypher = 0; i_cypher < _zipbagtocypher.Count - 1; i_cypher += 4)
            {
                byte[] bytes = new byte[4];
                bytes[1] = Convert.ToByte(_zipbagtocypher[i_cypher], 16);
                bytes[0] = Convert.ToByte(_zipbagtocypher[i_cypher + 1], 16);
                bytes[3] = Convert.ToByte(_zipbagtocypher[i_cypher + 2], 16);
                bytes[2] = Convert.ToByte(_zipbagtocypher[i_cypher + 3], 16);
                _zipbagcyphered += Encoding.Unicode.GetString(bytes);
            }
            DealerMessage.Document.Blocks.Clear();
            DealerMessage.AppendText("以下是交易明細：");
            DealerMessage.AppendText(Environment.NewLine);
            DealerMessage.AppendText(_zipbagcyphered);
            DealerMessage.AppendText(Environment.NewLine);
            DealerMessage.AppendText("會員總共買了：" + _zipbag.Count.ToString() + "包");
            DealerMessage.AppendText(Environment.NewLine);
            DealerMessage.AppendText("現在在第：" + (_zipbagposition + 1).ToString() + "包");
            DealerMessage.AppendText(Environment.NewLine);
            DealerMessage.AppendText("這包價值：" + _zipbag[_zipbagposition].PRICE.ToString() + "元");
            DealerMessage.AppendText(Environment.NewLine);
            DealerMessage.AppendText("這包有：" + _zipbag[_zipbagposition].DRUG.X.ToString() + "包🍁，" +
                _zipbag[_zipbagposition].DRUG.Y.ToString() + "包🍄，"+
                _zipbag[_zipbagposition].MEDICINE.X.ToString() + "顆💊，" +
                _zipbag[_zipbagposition].MEDICINE.Y.ToString() + "顆⛔，");

            _mudblock.Clear();
        }

    }
}
