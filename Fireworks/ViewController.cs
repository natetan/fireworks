using System;

using UIKit;

namespace Fireworks {
    public partial class ViewController : UIViewController {
        
        SimpleParticleGen fireworks;

        protected ViewController(IntPtr handle) : base(handle) {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            fireworks = new SimpleParticleGen(UIImage.FromFile(("xamlogo.png")), View);
            buttonStart.TouchUpInside += delegate(object sender, EventArgs e) {
                fireworks.Start();
            };
        }

        partial void ButtonAbout_TouchUpInside(UIButton sender) {
            var aboutViewController = (AboutViewController)this.Storyboard.InstantiateViewController("AboutViewController");
            this.PresentViewController(aboutViewController, true, null);
        }

        partial void SliderSize_ValueChanged(UISlider sender) {
            fireworks.ScaleMax = (nfloat)sliderSize.Value;
        }

        partial void SwitchNight_ValueChanged(UISwitch sender) {
            if (switchNight.On) {
                this.View.BackgroundColor = UIColor.FromRGB(25, 25, 112);
                buttonStart.TitleLabel.TextColor = UIColor.White;
                nightLabel.TextColor = UIColor.White;
                sizeLabel.TextColor = UIColor.White;
            } else {
                this.View.BackgroundColor = UIColor.White;
                buttonStart.TitleLabel.TextColor = UIColor.Black;
				nightLabel.TextColor = UIColor.Black;
				sizeLabel.TextColor = UIColor.Black;
            }
        }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
