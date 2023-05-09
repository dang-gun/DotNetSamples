using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace RhombusOutlinePoint;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	/// <summary>
	/// 좌표에 사용될 버튼 리스트
	/// </summary>
	private List<PointButtonModel> PointButtonList
		= new List<PointButtonModel>();


	/// <summary>
	/// 그리드 크기
	/// </summary>
	public Point MaxCount { get; set; }

	/// <summary>
	/// 클릭한 대상의 마지막 좌표
	/// </summary>
	private Point ClickTarget_Last { get; set; } = new Point(-1, -1);
	/// <summary>
	/// 클릭한 대상이 몇번 반복됐는지 횟수
	/// </summary>
	/// <remarks>
	/// 같은 대상을 클릭할때마다 1씩 증가 시킨다.<br />
	/// 다른 대상을 클릭하면 1로 초기화 시킴
	/// </remarks>
	private int ClickTarget_Count { get; set; } = 0;

	public MainWindow()
	{
		InitializeComponent();

		this.Button_Click(null, null);
	}

	private void Button_Click(object? sender, RoutedEventArgs? e)
	{
		int nX = Convert.ToInt32(this.txtX.Text);
		int nY = Convert.ToInt32(this.txtY.Text);


		this.GridSet(nX, nY);
	}

	/// <summary>
	/// 설정된 x,y 개수 만큼 그리드를 분할하고 버튼을 생성한다.
	/// </summary>
	/// <param name="nXCount"></param>
	/// <param name="nYCount"></param>
	private void GridSet(int nXCount, int nYCount)
	{
		//기존 내용을 지우고
		this.gridTarget.Children.Clear();
		this.gridTarget.RowDefinitions.Clear();
		this.gridTarget.ColumnDefinitions.Clear();

		this.PointButtonList.Clear();


		//크기 설정
		this.MaxCount = new Point(nXCount, nYCount);


		for (int x = 0; x < nXCount; ++x)
		{//x 개수만큼 생성
			this.gridTarget.ColumnDefinitions.Add(new ColumnDefinition());
		}//end for x
		for (int y = 0; y < nYCount; ++y)
		{//y 개수만큼 생성
			this.gridTarget.RowDefinitions.Add(new RowDefinition());
		}//end for y


		//버튼 생성
		for (int nY = 0; nY < nYCount; ++nY)
		{
			for (int nX = 0; nX < nXCount; ++nX)
			{
				PointButtonModel newPB
					= new PointButtonModel(nX, nY);

				newPB.OnPointButtonClick -= NewPB_OnPointButtonClick;
				newPB.OnPointButtonClick += NewPB_OnPointButtonClick;

				Grid.SetRow(newPB.ButtonUI, nY);
				Grid.SetColumn(newPB.ButtonUI, nX);

				this.gridTarget.Children.Add(newPB.ButtonUI);


				this.PointButtonList.Add(newPB);
			}
		}
	}

	/// <summary>
	/// 클릭됨
	/// </summary>
	/// <param name="sender"></param>
	private void NewPB_OnPointButtonClick(PointButtonModel sender)
	{
		if (sender.X == this.ClickTarget_Last.X
			&& sender.Y == this.ClickTarget_Last.Y)
		{//이전에 저장된 좌표와 클릭 좌표가 같다.

			//반복 카운터 증가
			++this.ClickTarget_Count;
		}
		else
		{//다르다

			//반복 카운터를 초기화 시키고
			this.ClickTarget_Count = 1;

			this.ClickTarget_Last
				= new Point(sender.X, sender.Y);
		}

		//중심점을 기준으로 지정된 거리만큼 떨어진 마름모 외각 좌표리스트 받기
		List<Point> listDiamondTile 
			= this.DiamondTile(this.ClickTarget_Count, sender.X, sender.Y);

		//찾아낸 좌표리스트와 일치하는 개체 리스트
		List<PointButtonModel> listTarget = new List<PointButtonModel>();

		foreach (Point itemPoint in listDiamondTile)
		{
			if ((0 <= itemPoint.X && itemPoint.X < this.MaxCount.X)
				&& (0 <= itemPoint.Y && itemPoint.Y < this.MaxCount.Y))
			{//체크하려는 좌표가 크기 안에 있다.

				//좌표와 일치하는 개체를 찾는다.
				PointButtonModel? findPB
					= this.PointButtonList
						.Find(f => f.X == itemPoint.X 
								&& f.Y == itemPoint.Y);

				if (findPB != null) 
				{//일치하는 개체가 있다.

					//리스트에 추가
					listTarget.Add(findPB);
				}
			}
		}//end foreach itemPoint


		//찾은 개체의 스토리보드 진행
		foreach (PointButtonModel item in listTarget)
		{
			item.storyboard.Begin();
		}//end foreach item
	}

	/// <summary>
	/// 해당 중심점을 기준으로 마름모 칸에 해당하는 외곽선의 좌표를 구해 리턴합니다.
	/// 마이너스(-)값도 출력 됩니다.
	/// </summary>
	/// <param name="nRange">기준으로 부터 거리</param>
	/// <param name="nCenterX">기준X</param>
	/// <param name="nCenterY">기준Y</param>
	/// <returns>외곽선 좌표 리스트</returns>
	private List<Point> DiamondTile(int nRange, int nCenterX, int nCenterY)
	{
		//외곽선 좌표
		List<Point> pointRange = new List<Point>();

		//범위가 한칸 늘어날때마다 4칸씩 추가 됩니다.
		//		1		2		3		4		5		6		7
		//		4		8		12		16		18		24		28
		//등차 수열이된다. a + ( n - 1 ) * d
		// 0 + ( 1 - 1 ) * 4 = 0
		// 0 + ( 2 - 1 ) * 4 = 4
		// 0 + ( 3 - 1 ) * 4 = 8


		for (int i = 0; i < nRange; ++i)
		{
			//1.위에서 왼쪽으로
			pointRange.Add(new Point(nCenterX - i, nCenterY - nRange + i));

			//2.왼쪽에서 아래쪽으로
			pointRange.Add(new Point(nCenterX - nRange + i, nCenterY + i));

			//3.아래에서 오른쪽으로
			pointRange.Add(new Point(nCenterX + i, nCenterY + nRange - i));

			//4.오른쪽에서 윗쪽으로
			pointRange.Add(new Point(nCenterX + nRange - i, nCenterY - i));
		}

		return pointRange;
	}
}
