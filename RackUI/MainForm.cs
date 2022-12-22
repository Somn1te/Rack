using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using RackParameters;
using RackBuilder;


namespace RackUI
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Объект класса с параметрами
		/// </summary>
		private RackParameter _parameters = new RackParameter();

		/// <summary>
		/// Словарь текстбокс - имя параметра
		/// </summary>
		public Dictionary<ParameterNames, TextBox> TextBoxDictionary { get; }

		/// <summary>
		/// Запуск формы
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			TextBoxDictionary = new Dictionary<ParameterNames, TextBox>()
			{
				{ParameterNames.HeightRack, textBoxHeigthRack},
				{ParameterNames.WidthSupport, textBoxWidthSupport},
				{ParameterNames.AmtHooks, textBoxAmtHooks},
				{ParameterNames.WidthHooks, textBoxWidthHooks},
				{ParameterNames.WidthRack, textBoxWidthRack},
				{ParameterNames.LengthSupport, textBoxLengthSupport},
				{ParameterNames.LengthStand, textBoxLengthStand}
			};
			SetDefault();
		}

		/// <summary>
		/// Метод, устанавливающий значение по умолчанию
		/// </summary>
		public void SetDefault()
		{
			_parameters = new RackParameter();
			foreach (var textBox in TextBoxDictionary)
			{
				var propertyName = textBox.Key;
				//TODO: рефлексия - зло, переделать
				switch (propertyName)
				{
					case ParameterNames.HeightRack:
						textBox.Value.Text = _parameters.HeightRack.ToString();
						break;
					case ParameterNames.LengthSupport:
						textBox.Value.Text = _parameters.LengthSupport.ToString();
						break;
					case ParameterNames.WidthSupport:
						textBox.Value.Text = _parameters.WidthSupport.ToString();
						break;
					case ParameterNames.AmtHooks:
						textBox.Value.Text = _parameters.AmtHooks.ToString();
						break;
					case ParameterNames.WidthHooks:
						textBox.Value.Text = _parameters.WidthHooks.ToString();
						break;
					case ParameterNames.WidthRack:
						textBox.Value.Text = _parameters.WidthRack.ToString();
						break;
					case ParameterNames.LengthStand:
						textBox.Value.Text = _parameters.LengthStand.ToString();
						break;
				}
			}
		}

		/// <summary>
		/// Обработчик ввода с клавиатуры
		/// </summary>
		/// <param name="sender">Объект</param>
		/// <param name="e">Событие</param>
		private void Textbox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar == '.') || (e.KeyChar == ','))
			{
				e.KeyChar = '.';
				TextBox txt = (TextBox)sender;
				if (txt.Text.Contains("."))
				{
					e.Handled = true;
				}

				return;
			}

			if (!(char.IsDigit(e.KeyChar)))
			{
				if ((e.KeyChar != (char)Keys.Back))
				{
					e.Handled = true;
				}
			}
		}


		/// <summary>
		/// Проверка введённых значений
		/// </summary>
		private void CheckValue()
		{
			foreach (var textBox in TextBoxDictionary)
			{
				if (textBox.Value.Text == "")
				{
					return;
				}

				_parameters.ErrorsDictionary.Remove(textBox.Key);
				textBox.Value.BackColor = Color.White;
				double.TryParse(textBox.Value.Text, NumberStyles.Float,
					CultureInfo.InvariantCulture, out var value);
				var propertyName = textBox.Key;
				//TODO: рефлексия - зло, переделать
				switch (propertyName)
				{
					case ParameterNames.HeightRack:
						_parameters.HeightRack = value ;
						break;
					case ParameterNames.LengthSupport:
						_parameters.LengthSupport = value ;
						break;
					case ParameterNames.WidthSupport:
						_parameters.WidthSupport = value;
						break;
					case ParameterNames.AmtHooks:
						_parameters.AmtHooks = (int)value;
						break;
					case ParameterNames.WidthHooks:
						_parameters.WidthHooks = value;
						break;
					case ParameterNames.WidthRack:
						_parameters.WidthRack = value;
						break;
					case ParameterNames.LengthStand:
						_parameters.LengthStand = value;
						break;
				}

				if (_parameters.ErrorsDictionary.ContainsKey(textBox.Key))
				{
					textBox.Value.BackColor = Color.IndianRed;
				}
			}
		}

		/// <summary>
		/// Обработчик изменения текста в полях
		/// </summary>
		/// <param name="sender">Объект</param>
		/// <param name="e">Событие</param>
		private void Textbox_TextChanged(object sender, EventArgs e)
		{
			var textbox = (TextBox)sender;
			CheckValue();
			//TODO: Не должно быть в GUI

			var widthRackMaxValue = DependenciesHelper.GetWidthRackMaxValue(
				_parameters.AmtHooks, _parameters.WidthHooks);
			var widthRackMinValue = DependenciesHelper.GetWidthRackMinValue(
				_parameters.AmtHooks, _parameters.WidthHooks);
			var lengthSupportMaxValue = DependenciesHelper.GetLengthSupportMaxValue(
				_parameters.WidthSupport);
			var lengthStandMaxValue = DependenciesHelper.GetLengthStandMaxValue(
				_parameters.WidthRack); 

			if (textbox == TextBoxDictionary[ParameterNames.WidthHooks])
			{
				labelWidthRackValue.Text = $"(от {widthRackMinValue} до " +
				                           $"{widthRackMaxValue} мм)";
				labelLengthStandValue.Text = $"(от 100 до " +
										   $"{lengthStandMaxValue} мм)";
			}

			if (textbox == TextBoxDictionary[ParameterNames.WidthSupport])
			{
				labelLengthSupportValue.Text = $"(от 400 до {lengthSupportMaxValue} мм)";
			}

			if (textbox == TextBoxDictionary[ParameterNames.AmtHooks])
			{
				labelWidthRackValue.Text = $"(от {widthRackMinValue} до " +
				                           $"{widthRackMaxValue} мм)";
				labelLengthStandValue.Text = $"(от 100 до " +
										   $"{lengthStandMaxValue} мм)";
			}

			if (textbox == TextBoxDictionary[ParameterNames.WidthRack])
			{
				labelLengthStandValue.Text = $"(от 100 до " +
										   $"{lengthStandMaxValue} мм)";
			}

		}

		/// <summary>
		/// Обработчик нажатия кнопки "Построить"
		/// </summary>
		/// <param name="sender">Объект</param>
		/// <param name="e">Событие</param>
		private void ButtonBuild_Click(object sender, EventArgs e)
		{
			if (_parameters.ErrorsDictionary.Any())
			{
				MessageBox.Show("Проверьте правильность ввода данных ", "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			else
			{
				var rackBuilder = new RackBuild(_parameters);
				rackBuilder.Build();
			}
		}
	}
}
