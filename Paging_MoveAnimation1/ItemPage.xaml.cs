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

namespace Paging_MoveAnimation1;

/// <summary>
/// ItemPage.xaml에 대한 상호 작용 논리
/// </summary>
public partial class ItemPage : Page
{
    /// <summary>
    /// 페이지 번호
    /// </summary>
    public int PageNumber { get; private set; }

    public ItemPage()
    {
        InitializeComponent();
    }

    public ItemPage(string sName, int nPageNumber)
    {
        InitializeComponent();

        this.NameSet(sName);
        this.PageNumberSet(nPageNumber);
    }

    public void NameSet(string sName)
    {
        this.labName.Content = sName;
    }

    public void PageNumberSet(int nPageNumber)
    {
        this.PageNumber = nPageNumber;
    }
}
