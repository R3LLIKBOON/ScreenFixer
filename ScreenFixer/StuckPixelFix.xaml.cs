using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScreenFixer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StuckPixelFix : Page
    {
        SpriteVisual backgroundSprite;
        public StuckPixelFix()
        {
            this.InitializeComponent();
        }

        private void Background_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationView.GetForCurrentView().TryEnterFullScreenMode();

            CreatBackgroundSprite();

            Background.SizeChanged += delegate
            {
                backgroundSprite.Size = new Vector2((float)Window.Current.Bounds.Width, (float)Window.Current.Bounds.Height);
            };

            await StartColorAnimation(backgroundSprite);

        }

        private void CreatBackgroundSprite()
        {
            var targetVisual = ElementCompositionPreview.GetElementVisual(Background);
            backgroundSprite = targetVisual.Compositor.CreateSpriteVisual();

            backgroundSprite.Size = new Vector2((float)Window.Current.Bounds.Width, (float)Window.Current.Bounds.Height);

            backgroundSprite.Brush = targetVisual.Compositor.CreateColorBrush(Colors.Red);

            ElementCompositionPreview.SetElementChildVisual(Background, backgroundSprite);
        }

        private async Task StartColorAnimation(SpriteVisual background)
        {
           
            await Task.Delay(1);

        
            background.Brush.StartAnimation("Color", CreateColorAnimation(background));
        }

        private  void ChangeToFullScreen(ApplicationView applicationView)
        {
            applicationView.TryEnterFullScreenMode();

        }
        private ColorKeyFrameAnimation CreateColorAnimation(Visual targetVisual)
        {
            Compositor compositor = targetVisual.Compositor;
            var colorAnimation = compositor.CreateColorKeyFrameAnimation();
            var easing = compositor.CreateStepEasingFunction();

            colorAnimation.InsertKeyFrame(0, Color.FromArgb(255,255,0,0),easing);
            colorAnimation.InsertKeyFrame(.5f, Color.FromArgb(255,0,255,0), easing);
            colorAnimation.InsertKeyFrame(1.0f, Color.FromArgb(255,0,0,255), easing);

            colorAnimation.Duration = TimeSpan.FromMilliseconds(150);
            colorAnimation.StopBehavior = AnimationStopBehavior.SetToInitialValue;
            colorAnimation.IterationBehavior = AnimationIterationBehavior.Forever;

            return colorAnimation;
        }
    }
}
