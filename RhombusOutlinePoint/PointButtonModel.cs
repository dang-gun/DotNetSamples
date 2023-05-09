using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RhombusOutlinePoint
{
	/// <summary>
	/// 좌표에 사용될 버튼 모델
	/// </summary>
	internal class PointButtonModel
	{
		#region 외부로 노출될 이벤트
		/// <summary>
		/// PointButton의 버튼이 눌렸다.
		/// </summary>
		/// <param name="sender"></param>
		public delegate void PointButtonClickDelegate(PointButtonModel sender);
		/// <summary>
		/// PointButton의 버튼이 눌렸음
		/// </summary>
		public event PointButtonClickDelegate? OnPointButtonClick;

		/// <summary>
		/// PointButton의 버튼이 눌렸음을 알린다.
		/// </summary>
		protected void OnPointButtonClickCall()
		{
			if (null != OnPointButtonClick)
			{
				this.OnPointButtonClick(this);
			}
		}
		#endregion

		/// <summary>
		/// 내가 사용중인 좌표 X
		/// </summary>
		public int X { get; }
		/// <summary>
		/// 내가 사용중인 좌표 Y
		/// </summary>
		public int Y { get; }

		/// <summary>
		/// UI로 사용될 버튼
		/// </summary>
		public Button ButtonUI { get; }


		public Storyboard storyboard = new Storyboard();

		public PointButtonModel(int nX, int nY) 
		{ 
			this.X = nX;
			this.Y = nY;


			this.ButtonUI = new Button();
			this.ButtonUI.Click -= ButtonUI_Click;
			this.ButtonUI.Click += ButtonUI_Click;

			this.ButtonUI.Content = string.Format("{0}, {1}", this.X, this.Y);


			ScaleTransform scale = new ScaleTransform(1.0, 1.0);
			this.ButtonUI.RenderTransformOrigin = new Point(0.5, 0.5);
			this.ButtonUI.RenderTransform = scale;

			DoubleAnimation growAnimation1 = new DoubleAnimation();
			growAnimation1.Duration = TimeSpan.FromMilliseconds(300);
			growAnimation1.From = 1;
			growAnimation1.To = 2;
			growAnimation1.AutoReverse = true;
			storyboard.Children.Add(growAnimation1);

			DoubleAnimation growAnimation2 = new DoubleAnimation();
			growAnimation2.Duration = TimeSpan.FromMilliseconds(300);
			growAnimation2.From = 1;
			growAnimation2.To = 2;
			growAnimation2.AutoReverse = true;
			storyboard.Children.Add(growAnimation2);

			Storyboard.SetTargetProperty(
				growAnimation1
				, new PropertyPath("RenderTransform.ScaleX"));
			Storyboard.SetTargetProperty(
				growAnimation2
				, new PropertyPath("RenderTransform.ScaleY"));

			Storyboard.SetTarget(growAnimation1, this.ButtonUI);
			Storyboard.SetTarget(growAnimation2, this.ButtonUI);

		}

		/// <summary>
		/// 클릭됨
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonUI_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			storyboard.Begin();


			this.OnPointButtonClickCall();
		}
	}
}
