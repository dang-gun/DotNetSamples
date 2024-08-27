using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace DG_PageMove;

/// <summary>
/// 페이지 이동에 대한 애니메이션 구현
/// </summary>
/// <remarks>
/// 오른쪽 왼쪽 이동만 있다.
/// </remarks>
public partial class PageMoveUC : UserControl
{
    #region 외부에서 연결할 이벤트

    /// <summary>
    /// 페이지 이동 애니메이션 관련 정보를 전달하기위한 대리자
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="pageNow">종료 후 현재 페이지</param>
    public delegate void PageMoveAniDelegate(PageMoveUC sender, Page? pageNow);

    /// <summary>
    /// 페이지 이동 애니메이션이 끝나면 발생하는 이벤트
    /// </summary>
    public event PageMoveAniDelegate? OnAniEnd;
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
    /// 현제 보고 있는 페이지 개체
    /// </summary>
    public Page? NowPage { get; private set; }

    /// <summary>
    /// 애니메이션 이동 가로 거리
    /// <para>애니메이션이 가로로 이동할때 거리로 왼쪽/오른쪽에서 등장하는 최대 거리를 의미한다.</para>
    /// </summary>
    public double AniMoveWidth { get; private set; }

    /// <summary>
    /// 애니메이션 이동 가로 거리를 지금 차지하고 있는 크기만큼으로 설정한다.
    /// </summary>
    public void AniMoveWidthSet()
    {
        //지금 차지하고 있는 가로 크기로 지정한다.
        this.AniMoveWidth = this.CurrentFrame.ActualWidth;
    }
    /// <summary>
    /// 애니메이션 이동 가로 거리를 지정한 크기로 정한다.
    /// </summary>
    /// <param name="dAniMoveWidth"></param>
    public void AniMoveWidthSet(double dAniMoveWidth)
    {
        this.AniMoveWidth = dAniMoveWidth;
    }

    /// <summary>
    /// 애니메이션이 재생중인지 여부
    /// </summary>
    private bool Ani_Playing = false;

    public PageMoveUC()
    {
        InitializeComponent();


        // 초기 페이지 설정
        //this.FirstSet(new ItemPage("1"));
    }

    public PageMoveUC(Page pageFirst)
    {
        InitializeComponent();

        this.WithoutAnimation(pageFirst);
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {

        //애니메이션 이동 가로 거리를 화면에 표시된 영역의 크기만큼으로 설정한다.
        if(0 == this.AniMoveWidth)
        {//이미 설정된 값이 없다.

            //설정된 값이 없을때만 초기화 한다.
            this.AniMoveWidth = CurrentFrame.ActualWidth;
        }
    }

    /// <summary>
    /// 왼쪽으로 이동하는 애니메이션
    /// <para>pageNew개체가 오른쪽 생성되어 왼쪽으로 이동한다.</para>
    /// </summary>
    /// <param name="pageNew">이동 목표 페이지</param>
    /// <returns>애니메이션이 실행되었는지 여부</returns>
    public bool PageMove_Left(Page pageNew)
    {
        return NavigateToPage(pageNew, this.NowPage, false);
    }
    /// <summary>
    /// 오른쪽으로 이동하는 애니메이션
    /// <para>pageNew개체가 왼쪽에서 생성되어 오른쪽으로 이동한다.</para>
    /// </summary>
    /// <param name="pageNew">이동 목표 페이지</param>
    /// <returns>애니메이션이 실행되었는지 여부</returns>
    public bool PageMove_Right(Page pageNew)
    {
        return NavigateToPage(pageNew, this.NowPage, true);
    }

    /// <summary>
    /// 페이지 이동 애니메이션
    /// </summary>
    /// <remarks>
    /// 여기서 말하는 오른쪽은 애니메이션이 왼쪽에서 생성되어 오른쪽으로 이동함을 의미한다.
    /// </remarks>
    /// <param name="pageNew"></param>
    /// <param name="pageOld"></param>
    /// <param name="bRight">오른쪽으로 이동할지 여부</param>
    /// <returns></returns>
    private bool NavigateToPage(Page pageNew, Page? pageOld, bool bRight)
    {
        if(true == this.Ani_Playing)
        {//재생중이다.

            //이동하지 않음
            return false;
        }

        this.Ani_Playing = true;

        // 새로운 페이지를 NextFrame에 로드
        NextFrame.Visibility = Visibility.Visible;
        NextFrame.Navigate(pageNew);

        // TranslateTransform 설정
        TranslateTransform oldPageTransform = new TranslateTransform();
        TranslateTransform newPageTransform = new TranslateTransform();

        CurrentFrame.RenderTransform = oldPageTransform;
        NextFrame.RenderTransform = newPageTransform;

        // 애니메이션 설정
        DoubleAnimation oldPageAnimation = new DoubleAnimation
        {
            From = 0,
            To = bRight ? -this.AniMoveWidth : this.AniMoveWidth,
            Duration = TimeSpan.FromSeconds(0.5),
            EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
        };

        DoubleAnimation newPageAnimation = new DoubleAnimation
        {
            From = bRight ? this.AniMoveWidth : -this.AniMoveWidth,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.5),
            EasingFunction = new QuarticEase { EasingMode = EasingMode.EaseInOut }
        };

        // 애니메이션 완료 후 페이지 전환
        oldPageAnimation.Completed += (s, a) =>
        {
            // 기존 페이지를 숨기지 않고 위치만 변경
            // 변환 초기화
            CurrentFrame.RenderTransform = null;
            // 이전 페이지로 전환
            CurrentFrame.Navigate(pageNew);
            // 페이지 보이기
            CurrentFrame.Visibility = Visibility.Visible;
            // NextFrame 숨기기
            NextFrame.Visibility = Visibility.Collapsed; 

            //이동 페이지를 지금 페이지로 저장
            this.NowPage = pageNew;
            //Debug.WriteLine("저장 : " + this.NowPage.labName.Content);
            //Debug.WriteLine($"저장 : {((ItemPage)newPage).labName.Content}, {((ItemPage)oldPage).labName.Content}");


            //애니메이션 끝남을 알림
            this.Ani_Playing = false;
            this.OnAniEndCall();
        };

        // 애니메이션 시작
        oldPageTransform.BeginAnimation(TranslateTransform.XProperty, oldPageAnimation);
        newPageTransform.BeginAnimation(TranslateTransform.XProperty, newPageAnimation);

        return true;
    }

    /// <summary>
    /// 애니메이션 없이 페이지 표시한다.
    /// </summary>
    /// <param name="newPage"></param>
    public void WithoutAnimation(Page newPage)
    {
        //금 페이지로 저장
        this.NowPage = newPage;

        //이동 완료 시킴
        CurrentFrame.Navigate(this.NowPage);
        // 페이지 보이기
        CurrentFrame.Visibility = Visibility.Visible; 
    }
}


