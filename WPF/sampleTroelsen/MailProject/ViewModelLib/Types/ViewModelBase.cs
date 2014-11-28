namespace ViewModelLib.Types
{
	using System;
	using System.ComponentModel;
	using System.Diagnostics;

	public interface INotifyPropertyChangedWithRaise : INotifyPropertyChanged
	{
		void RaisePropertyChanged(string propertyName);
	}
	
	/// <summary>
	/// Base class for ViewModel pattern implementation
	/// </summary>
	public class ViewModelBase : INotifyPropertyChangedWithRaise
	{
		/// <summary>
		/// Raised when property changed
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raise PropertyChanged event
		/// </summary>
		/// <param name="propertyName">Changed property name</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			this.VerifyPropertyName(propertyName);

			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public void RaisePropertyChanged(string propertyName)
		{
			OnPropertyChanged(propertyName);
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			// Verify that the property name matches a real,  
			// public, instance property on this object.
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				string msg = "Invalid property name: " + propertyName;

				throw new Exception(msg);
			}
		}
	}
}