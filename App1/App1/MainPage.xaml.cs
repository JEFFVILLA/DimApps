using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace App1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private double doublex;
        private double doubley;
        private double opacidad = 1.0;
        private int _mode = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void imagen_Holding(object sender, HoldingRoutedEventArgs e)
        {
         this.listView1.Items.Clear();
        
        }

        private void imagen_DoubleTap(object sender, DoubleTappedRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            source.Opacity = 1.0;
            opacidad = 1.0;
        }

        private void imagen_Tap(object sender, TappedRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            opacidad = opacidad - 0.1;
            source.Opacity = opacidad;
        }
      



        private void imagen_PointerPointerPressed(object sender,PointerRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            this.listView1.Items.Add("La imagen fue presionada" + "-" + source.Name);
                      
        }
        private void imagen_PointerPointerRelease(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            this.listView1.Items.Add("La imagen fue soltada" + "-" + source.Name);

        }
        private void imagen_PointerPointerExited(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            this.listView1.Items.Add("Salio de la Imagen" + "-" + source.Name);

        }
        private void imagen_PointerPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            this.listView1.Items.Add("Entro en la imagen" + "-" + source.Name);

        }
        private void imagen_PointerPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            

        }
        private void imagen_PointerPointerCancel(object sender, PointerRoutedEventArgs e)
        {
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            this.listView1.Items.Insert(0, "Cancelar");

        }
        private void imagen_PointerPointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            this.listView1.Items.Insert(0, "CaptureLost");
        }
        private void imagen_PointerPointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            doublex = e.GetCurrentPoint(imagen).Position.X;
            doubley = e.GetCurrentPoint(imagen).Position.Y;
            this.listView1.Items.Add("WheelChanged"+ "-"+source.Name);
        }

        private void imagem_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            FrameworkElement source = (FrameworkElement)e.OriginalSource;
            Point center = this.TransformToVisual(source).TransformPoint(e.Position);
            TransformGroup ct = source.RenderTransform as TransformGroup;

            RotateTransform rotation = new RotateTransform();
            rotation.CenterX = center.X;
            rotation.CenterY = center.Y;
            rotation.Angle = e.Delta.Rotation;
            ct.Children.Add(rotation);

            ScaleTransform scaling = new ScaleTransform();
            scaling.CenterX = center.X;
            scaling.CenterY = center.Y;
            scaling.ScaleX = e.Delta.Scale;
            scaling.ScaleY = e.Delta.Scale;
            ct.Children.Add(scaling);
            
            if(_mode == 1)
            {
                TranslateTransform translation = new TranslateTransform();
                translation.X = e.Delta.Translation.X;
                translation.Y = e.Delta.Translation.Y;
                ct.Children.Add(translation);
            }
                 
        }

       

        private void Activar_Click(object sender, RoutedEventArgs e)
        {
            _mode = 1;
            this.imagen1.Visibility = Visibility.Visible;
            this.imagen2.Visibility = Visibility.Visible;
        }

        private void Desactivar_Click(object sender, RoutedEventArgs e)
        {
            _mode = 0;
            this.imagen1.Visibility = Visibility.Collapsed;
            this.imagen2.Visibility = Visibility.Collapsed;
        }

    }
}
