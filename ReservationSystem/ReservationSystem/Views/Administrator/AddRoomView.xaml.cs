using ReservationSystem.Models;
using ReservationSystem.ViewModels.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReservationSystem.Views.Administrator
{
    /// <summary>
    /// Interaction logic for AddRoomView.xaml
    /// </summary>
    public partial class AddRoomView : UserControl
    {

        private System.Windows.Point offset = new System.Windows.Point();
        UIElement dragObject;

        public AddRoomView()
        {
            InitializeComponent();
        }


        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = offset - mousePos;

            if (!(e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)))
            {
                return;
            }

            if (dragObject == null) 
            {
                return;
            }
            var position = e.GetPosition(sender as IInputElement);
            var yMove = position.Y - offset.Y;
            var xMove = position.X - offset.X;

            var tableStackPanel = dragObject as StackPanel;
            dragObject = tableStackPanel;
            var table = (Table)tableStackPanel.DataContext;

            if (xMove > 930)
            {
                table.TableCoordinates.X = 930;
            }
            else if (xMove < 0)
            {
                table.TableCoordinates.X = 0;
            }
            else 
            {
                table.TableCoordinates.X = xMove;
            }

            if (yMove > 930)
            {
                table.TableCoordinates.Y = 930;
            }
            else if (yMove < 0)
            {
                table.TableCoordinates.Y = 0;
            }
            else 
            {
                table.TableCoordinates.Y = yMove;
            }
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var tableStackPanel = sender as StackPanel;
            dragObject = tableStackPanel;
            var table = (Table)tableStackPanel.DataContext;

            var mainCanvas = FindAncestor<Canvas>(tableStackPanel);

            offset = e.GetPosition(mainCanvas);
            offset.X -= table.TableCoordinates.X;
            offset.Y -= table.TableCoordinates.Y;

            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Cross;

            mainCanvas.CaptureMouse();
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }


        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            dragObject = null;
            var mainCanvas = FindAncestor<Canvas>(sender as UIElement);
            mainCanvas.ReleaseMouseCapture();

            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Cross && this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void StackPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var tableStackPanel = sender as StackPanel;
            dragObject = tableStackPanel;
            var table = (Table)tableStackPanel.DataContext;
            AddRoomViewModel.RemoveTableCommand.Execute(table);
        }
    }
}
