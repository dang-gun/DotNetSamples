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

namespace AnimationPage;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        //FadeAniFrame.Navigate(new UcNewPage("1")); // 초기 페이지 설정

        MainFrame.Navigate(new UcNewPage("1")); // 초기 페이지 설정
    }

    #region Fade
    private void Fade_PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        // 새 페이지로 전환할 때 애니메이션 효과 적용
        var newPage = new UcNewPage("1"); // 이동할 페이지
        Fade_AniPageTransition(newPage);
    }
    private void Fade_NextPage_Click(object sender, RoutedEventArgs e)
    {
        // 새 페이지로 전환할 때 애니메이션 효과 적용
        var newPage = new UcNewPage("2"); // 이동할 페이지
        Fade_AniPageTransition(newPage);
    }

    private void Fade_AniPageTransition(Page newPage)
    {
        // 애니메이션 정의
        var fadeOutAnimation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5));
        fadeOutAnimation.Completed += (s, a) =>
        {
            FadeAniFrame.Navigate(newPage);
            var fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            fadeInAnimation.Completed += (s2, a2) => FadeAniFrame.Opacity = 1; // 최종 상태 설정
            FadeAniFrame.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
        };
        FadeAniFrame.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
    }
    #endregion


    #region Move
    private void Move_PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        var newPage = new UcNewPage("1"); // 이동할 페이지
        Move_AnimatePageTransition(newPage,4); // 애니메이션 메서드 호출
    }
    private void Move_NextPage_Click(object sender, RoutedEventArgs e)
    {
        var newPage = new UcNewPage("2"); // 이동할 페이지
        Move_AnimatePageTransition(newPage,2); // 애니메이션 메서드 호출
    }

    private void Move_AnimatePageTransition(Page newPage, short nMove)
    {
        // 새 페이지를 설정
        MainFrame.Content = newPage;

        // TranslateTransform 설정
        var translateTransform = new TranslateTransform();
        MainFrame.RenderTransform = translateTransform;


        DoubleAnimation? moveOutAnimation = null;
        DoubleAnimation? moveInAnimation = null;

        double dStart = 0;

        switch (nMove)
        {
            case 1://위
                break;
            case 2://오른쪽
                {
                    // 애니메이션 정의: 오른쪽으로 이동
                    moveOutAnimation = new DoubleAnimation(0, MainFrame.ActualWidth, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    moveInAnimation = new DoubleAnimation(MainFrame.ActualWidth, 0, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    dStart = -MainFrame.ActualWidth;
                }
                break;
            case 3://아래
                break;
            case 4://왼쪽
                {
                    // 애니메이션 정의: 오른쪽으로 이동
                    moveOutAnimation = new DoubleAnimation(0, -MainFrame.ActualWidth, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    moveInAnimation = new DoubleAnimation(-MainFrame.ActualWidth, 0, TimeSpan.FromSeconds(0.5))
                    {
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
                    };

                    dStart = -MainFrame.ActualWidth;
                }
                break;
        }
        

        if(null != moveOutAnimation)
        {
            // 페이지가 오른쪽으로 이동하는 애니메이션
            translateTransform.BeginAnimation(TranslateTransform.XProperty, moveOutAnimation);

            // 애니메이션 완료 후 새 페이지로 전환
            moveOutAnimation.Completed += (s, a) =>
            {
                MainFrame.Content = newPage; // 새 페이지 설정
                translateTransform.X = dStart; // 초기 위치 재설정
                translateTransform.BeginAnimation(TranslateTransform.XProperty, moveInAnimation); // 왼쪽에서 들어오는 애니메이션
            };
        }

        
    }
    #endregion
}