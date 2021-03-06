﻿using Plugin.Vibrate.Abstractions;
using System;
using Windows.Foundation.Metadata;

namespace Plugin.Vibrate
{
	/// <summary>
	/// Vibrate Implementation
	/// </summary>
    public class Vibrate : IVibrate
    {

		/// <summary>
		/// Gets if device can vibrate
		/// </summary>
		public bool CanVibrate
		{
			get
			{
				if (ApiInformation.IsTypePresent("Windows.Phone.Devices.Notification.VibrationDevice"))
				{
					var v = Windows.Phone.Devices.Notification.VibrationDevice.GetDefault();

					if (v != null)
						return true;
				}

				return false;
			}
		}

		/// <summary>
		/// Vibrate the phone for specified amount of time
		/// </summary>
		/// <param name="vibrateSpan">Time span to vibrate. 500ms is default if null</param>
		public void Vibration(TimeSpan? vibrateSpan = null)
        {
            var milliseconds = vibrateSpan.HasValue ? vibrateSpan.Value.Milliseconds : 500;

            if (ApiInformation.IsTypePresent("Windows.Phone.Devices.Notification.VibrationDevice"))
            {
                var v = Windows.Phone.Devices.Notification.VibrationDevice.GetDefault();

				if (v == null)
				{
					System.Diagnostics.Debug.WriteLine("Default vibration device not found.");
					return;
				}

				if (milliseconds < 0)
                    milliseconds = 0;
                else if (milliseconds > 5000)
                    milliseconds = 5000;

                var time = TimeSpan.FromMilliseconds(milliseconds);
                v.Vibrate(time);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Vibration not supported on this device family.");
            }
        }
    }
}
