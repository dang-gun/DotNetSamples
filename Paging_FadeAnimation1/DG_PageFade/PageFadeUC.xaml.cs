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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DG_PageFade;

/// <summary>
/// PageFadeUC.xaml에 대한 상호 작용 논리
/// </summary>
public partial class PageFadeUC : UserControl
{
    #region 외부에서 연결할 이벤트

    /// <summary>
    /// 페이지 이동 애니메이션 관련 정보를 전달하기위한 대리자
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="pageNow">종료 후 현재 페이지</param>
    public delegate void PageFadeAniDelegate(PageFadeUC sender, Page? pageNow);

    /// <summary>
    /// 페이지 이동 애니메이션이 끝나면 발생하는 이벤트
    /// </summary>
    public event PageFadeAniDelegate? OnAniEnd;
    /// <summary>
    /// 페이지 이동 애니메이션이 끝나면 발생하는 이벤트 호출
    /// </summary>
    private void OnAniEndCall()
    {
        if (this.OnAniEnd != null)
        {
            this.OnAniEnd(this, this.NowPage);
        }
    }
    #endregion

    /// <summary>
    /// 현재 보고 있는 페이지 개체
    /// </summary>
    public Page? NowPage { get; private set; }

    /// <summary>
    /// 애니메이션이 재생중인지 여부
    /// </summary>
    private bool Ani_Playing = false;

    public PageFadeUC()
    {
        InitializeComponent();
    }

    public bool NavigateToPage(Page pageNew)
    {
        if (false == this.NavigateToCheck())
        {//재생중이다.

            //이동하지 않음
            return false;
        }

        // 페이드 아웃 애니메이션
        var fadeOutAnimation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5));
        fadeOutAnimation.Completed += (s, e) =>
        {
            CurrentFrame.Navigate(pageNew);
            // 페이드 인 애니메이션
            var fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.5));
            fadeInAnimation.Completed += (s, e) =>
            {
                // 애니메이션 완료 후 추가 작업
            };
            CurrentFrame.Opacity = 0;
            CurrentFrame.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
        };
        CurrentFrame.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);

        return true;
    }

    /// <summary>
    /// 페이지 이동이 가능한 상태인지 체크한다.
    /// </summary>
    /// <returns></returns>
    public bool NavigateToCheck()
    {
        bool bReturn = false;

        if (false == this.Ani_Playing)
        {//재생중이 아니다.

            //이동하지 않음
            bReturn = true;
        }

        return bReturn;
    }

    /// <summary>
    /// 애니메이션 없이 페이지 표시한다.
    /// </summary>
    /// <param name="newPage"></param>
    public void WithoutAnimation(Page newPage)
    {
        //지금 페이지로 저장
        this.NowPage = newPage;

        //이동 완료 시킴
        CurrentFrame.Navigate(this.NowPage);
        // 페이지 보이기
        CurrentFrame.Visibility = Visibility.Visible;
    }
}
