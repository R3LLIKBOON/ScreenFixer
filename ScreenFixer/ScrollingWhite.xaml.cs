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
    public sealed partial class ScrollingWhite : Page
    {
        Vector3KeyFrameAnimation repositionAnimation;
        public ScrollingWhite()
        {
            this.InitializeComponent();
            InitializeAnimation();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {


            var targetVisual = ElementCompositionPreview.GetElementVisual(WhiteBar);


           await StartAnimation(targetVisual);

        }

        private async Task StartAnimation(Visual targetVisual)
        {
            await Task.Delay(1);
            targetVisual.StartAnimation("Offset", repositionAnimation);
        }


        private void InitializeAnimation()
        {
            var targetVisual = ElementCompositionPreview.GetElementVisual(WhiteBar);
            Compositor compositor = targetVisual.Compositor;

            // Create an animation to animate targetVisual's Offset property to its final value
             repositionAnimation = compositor.CreateVector3KeyFrameAnimation();
            // repositionAnimation.InsertKeyFrame(1, new Vector3(0, 0, 0),compositor.CreateLinearEasingFunction());
            repositionAnimation.InsertKeyFrame(1, new Vector3(1500, 0, 0),compositor.CreateLinearEasingFunction());
            repositionAnimation.Duration = TimeSpan.FromSeconds(2);
            //repositionAnimation.Target = "Offset";

            repositionAnimation.StopBehavior = AnimationStopBehavior.SetToInitialValue;
            repositionAnimation.DelayTime = TimeSpan.FromSeconds(0);

            repositionAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
            //repositionAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");


            // Run this animation when the Offset Property is changed
            //  var repositionAnimations = compositor.CreateImplicitAnimationCollection();
            //  repositionAnimations["Offset"] = repositionAnimation;

            //targetVisual.ImplicitAnimations = repositionAnimations;
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            var targetVisual = ElementCompositionPreview.GetElementVisual(WhiteBar);
            targetVisual.StartAnimation("Offset", repositionAnimation);

            //targetVisual.Offset = new System.Numerics.Vector3(120f, 0f, 0f);

        }
    }
}
