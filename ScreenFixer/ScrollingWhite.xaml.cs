using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Gaming.Input;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScreenFixer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScrollingWhite : Page
    {
        

        public ScrollingWhite()
        {
            this.InitializeComponent();
        }

      


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();

        
         
         
         
         
         
            


            

                 await StartScrollAnimation(WhiteBar);

        }

        private async Task StartScrollAnimation(UIElement targetElement)
        {
            var targetVisual = ElementCompositionPreview.GetElementVisual(targetElement);
            
            //NOTE Delay is a work around for animation not starting because UI was not rendered
            await Task.Delay(1);
            targetVisual.StartAnimation("Offset", CreateScrollAnimation(targetVisual));
        }


        private Vector3KeyFrameAnimation CreateScrollAnimation(Visual targetVisual)
        {
            Vector3KeyFrameAnimation scrollAnimation;

            Compositor compositor = targetVisual.Compositor;

            scrollAnimation = compositor.CreateVector3KeyFrameAnimation();

            float screenWidth = (float)Window.Current.Bounds.Width;
            scrollAnimation.InsertKeyFrame(1, new Vector3(screenWidth, 0, 0), compositor.CreateLinearEasingFunction());

            scrollAnimation.Duration = TimeSpan.FromSeconds(2);
            scrollAnimation.Target = "Offset";
            scrollAnimation.StopBehavior = AnimationStopBehavior.SetToInitialValue;
            scrollAnimation.IterationBehavior = AnimationIterationBehavior.Forever;

            return scrollAnimation;
        }

        private void Background_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
