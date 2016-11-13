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
    public sealed partial class ColorCycle : Page
    {
        SpriteVisual backgroundSprite;
        public ColorCycle()
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

        private ColorKeyFrameAnimation CreateColorAnimation(Visual targetVisual)
        {
            Compositor compositor = targetVisual.Compositor;
            var colorAnimation = compositor.CreateColorKeyFrameAnimation();
            var transition = compositor.CreateStepEasingFunction();


            colorAnimation.InsertKeyFrame(.0f, Color.FromArgb(255, 255, 255, 255),transition);
            colorAnimation.InsertKeyFrame(.05f, Color.FromArgb(255, 198, 198, 198), transition);
            colorAnimation.InsertKeyFrame(.1f, Color.FromArgb(255, 145, 145, 145), transition);
            colorAnimation.InsertKeyFrame(.15f, Color.FromArgb(255, 94, 94, 94), transition);
            colorAnimation.InsertKeyFrame(.2f, Color.FromArgb(255, 48, 48, 48), transition);
            colorAnimation.InsertKeyFrame(.25f, Color.FromArgb(255, 254, 0, 0), transition);
            colorAnimation.InsertKeyFrame(.3f, Color.FromArgb(255, 225, 0, 0), transition);
            colorAnimation.InsertKeyFrame(.35f, Color.FromArgb(255, 200, 0, 0), transition);
            colorAnimation.InsertKeyFrame(.4f, Color.FromArgb(255, 175, 0, 0), transition);
            colorAnimation.InsertKeyFrame(.45f, Color.FromArgb(255, 150, 0, 0), transition);
            colorAnimation.InsertKeyFrame(.5f, Color.FromArgb(255, 0, 255, 0), transition);
            colorAnimation.InsertKeyFrame(.55f, Color.FromArgb(255, 0, 225, 0), transition);
            colorAnimation.InsertKeyFrame(.6f, Color.FromArgb(255, 0, 200, 0), transition);
            colorAnimation.InsertKeyFrame(.65f, Color.FromArgb(255, 0, 175, 0), transition);
            colorAnimation.InsertKeyFrame(.7f, Color.FromArgb(255, 0, 150, 0), transition);
            colorAnimation.InsertKeyFrame(.75f, Color.FromArgb(255, 0, 0, 255), transition);
            colorAnimation.InsertKeyFrame(.8f, Color.FromArgb(255, 0, 0, 225), transition);
            colorAnimation.InsertKeyFrame(.85f, Color.FromArgb(255, 0, 0, 200), transition);
            colorAnimation.InsertKeyFrame(.9f, Color.FromArgb(255, 0, 0, 175), transition);
            colorAnimation.InsertKeyFrame(.95f, Color.FromArgb(255, 0, 0, 150), transition);


            colorAnimation.Duration = TimeSpan.FromSeconds(200);
            colorAnimation.StopBehavior = AnimationStopBehavior.SetToInitialValue;
            colorAnimation.IterationBehavior = AnimationIterationBehavior.Forever;

            return colorAnimation;
        }
    }
}
