using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TouchMovePage;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// 마우스나 터치가 눌린 상태 여부
    /// </summary>
    private bool MouseDownIs = false;
    /// <summary>
    /// 마우스나 터치가 눌렸을때 위치
    /// </summary>
    private Point MouseDownPosition = new Point(0, 0);

    public MainWindow()
    {
        InitializeComponent();

        CurrentFrame.Navigate(new UcNewPage("1")); // 초기 페이지 설정
    }

    private void btnLeft_Click(object sender, RoutedEventArgs e)
    {
        NavigateToPage(new UcNewPage("1"), new UcNewPage("2"), true);
    }

    private void btnRight_Click(object sender, RoutedEventArgs e)
    {
        NavigateToPage(new UcNewPage("2"), new UcNewPage("1"), false);
    }

    private void NavigateToPage(Page newPage, Page oldPage, bool isRight)
    {
        // 새로운 페이지를 NextFrame에 로드
        NextFrame.Visibility = Visibility.Visible;
        NextFrame.Navigate(newPage);

        // TranslateTransform 설정
        TranslateTransform oldPageTransform = new TranslateTransform();
        TranslateTransform newPageTransform = new TranslateTransform();

        CurrentFrame.RenderTransform = oldPageTransform;
        NextFrame.RenderTransform = newPageTransform;

        // 애니메이션 설정
        DoubleAnimation oldPageAnimation = new DoubleAnimation
        {
            From = 0,
            To = isRight ? -CurrentFrame.ActualWidth : CurrentFrame.ActualWidth,
            Duration = TimeSpan.FromSeconds(0.5),
            EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
        };

        DoubleAnimation newPageAnimation = new DoubleAnimation
        {
            From = isRight ? CurrentFrame.ActualWidth : -CurrentFrame.ActualWidth,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.5),
            EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
        };

        // 애니메이션 완료 후 페이지 전환
        oldPageAnimation.Completed += (s, a) =>
        {
            // 기존 페이지를 숨기지 않고 위치만 변경
            CurrentFrame.RenderTransform = null; // 변환 초기화
            CurrentFrame.Visibility = Visibility.Visible; // 페이지 보이기
        };

        // 애니메이션 시작
        oldPageTransform.BeginAnimation(TranslateTransform.XProperty, oldPageAnimation);
        newPageTransform.BeginAnimation(TranslateTransform.XProperty, newPageAnimation);
    }



    private void gridMain_TouchDown(object sender, TouchEventArgs e)
    {
        this.MouseDownIs = true;
        this.MouseDownPosition = e.GetTouchPoint(this).Position;
    }

    private void gridMain_TouchUp(object sender, TouchEventArgs e)
    {
        this.Grid_TouchMoveCheck(e.GetTouchPoint(this).Position);
    }

    private void gridMain_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.MouseDownIs = true;
        this.MouseDownPosition = e.GetPosition(this);
        Debug.WriteLine($" MouseDown : {this.MouseDownPosition}");
    }

    private void gridMain_MouseUp(object sender, MouseButtonEventArgs e)
    {
        this.Grid_TouchMoveCheck(e.GetPosition(this));
    }


    private void Grid_TouchMoveCheck(Point pointNew)
    {
        Debug.WriteLine($" Grid_TouchMoveCheck : {pointNew}");
        if (pointNew.X < this.MouseDownPosition.X)
        {
            // 왼쪽으로 스크롤
            NavigateToPage(new UcNewPage("1"), new UcNewPage("2"), true);
        }
        else if (pointNew.X > this.MouseDownPosition.X)
        {

            // 오른쪽으로 스크롤
            NavigateToPage(new UcNewPage("2"), new UcNewPage("1"), false);
        }
    }

}