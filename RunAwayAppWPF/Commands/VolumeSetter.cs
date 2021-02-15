using CoreAudioApi;
using System;
using WindowsInput;
using WindowsInput.Native;

namespace RunAwayAppWPF
{
    class VolumeSetter : ICommand
    {
        public bool HideAfterExecuting { get; set; } = true;

        private MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();

        public void Execute(string[] args)
        {
            Intermediary.MustBeHidden = HideAfterExecuting;

            var device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);

            switch(args[0])
            {
                case "mute":
                    device.AudioEndpointVolume.Mute = true;
                    break;

                case "!mute" :
                case "unmute":
                    device.AudioEndpointVolume.Mute = false;
                    break;

                case "panel":
                    var inputSimulator = new InputSimulator();
                    inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_G);
                    break;

                default:
                    int volume = Convert.ToInt32(args[0]);
                    device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)volume / 100f;
                    break;
            }
        }
    }
}
