using System;
using Plugin.Vibrate.Abstractions;
using Tizen.System;

namespace Plugin.Vibrate
{
	/// <summary>
	/// Vibration Implentation on Tizen
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
				string profile = null;
				Information.TryGetValue<string>("tizen.org/feature/profile", out profile);
				if (profile.StartsWith("m") || profile.StartsWith("M")) // Mobile
				{
					return true;
				}
				else if (profile.StartsWith("w") || profile.StartsWith("W")) // Wearable
				{
					return true;
				}
				else if (profile.StartsWith("t") || profile.StartsWith("T")) // Tv
				{
					return false;
				}
				else if (profile.StartsWith("i") || profile.StartsWith("I")) // Ivi
				{
					return false;
				}
				else
					return false;
			}
		}

		/// <summary>
		/// Vibrate the phone for specified amount of time
		/// </summary>
		/// <param name="vibrateSpan">Time span to vibrate. 500ms is default if null</param>
		public void Vibration(TimeSpan? vibrateSpan = null)
		{
			var milliseconds = vibrateSpan.HasValue ? vibrateSpan.Value.TotalMilliseconds : 500;
			if (Vibrator.Vibrators.Count > 0)
			{
				var vibrator = Vibrator.Vibrators[0];
				try
				{
					if (milliseconds < 0)
						milliseconds = 0;
					vibrator.Vibrate((int)milliseconds, 100);
				}
				catch
				{
					Console.WriteLine("Unable to vibrate Tizen device.");
				}
			}
			else
			{
				Console.WriteLine("Number of vibratos can't be zero");
			}
		}
	}
}
