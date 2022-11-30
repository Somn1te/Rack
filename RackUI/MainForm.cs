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
				{ParameterNames.LengthSupport, textBoxLengthSupport}
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
				//рефликсия
				var property = _parameters.GetType().GetProperty(propertyName.ToString());
				textBox.Value.Text = property?.GetValue(_parameters).ToString();
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
				var property = _parameters.GetType().GetProperty(textBox.Key.ToString());
				if (property.PropertyType == typeof(int))
				{
					property?.SetValue(_parameters, (int)value);
				}
				else
				{
					property?.SetValue(_parameters, value);
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
		if (textbox == TextBoxDictionary[ParameterNames.WidthHooks])
			{
				labelWidthRackValue.Text = $"(от {_parameters.AmtHooks * _parameters.WidthHooks + 100} до " +
				                           $"{_parameters.AmtHooks * _parameters.WidthHooks + 150} мм)";
				labelLengthSupportValue.Text = $"(от 400 до {_parameters.WidthSupport + 250} мм)";
			}

			if (textbox == TextBoxDictionary[ParameterNames.AmtHooks])
			{
				labelWidthRackValue.Text = $"(от {_parameters.AmtHooks * _parameters.WidthHooks + 100} до " +
				                           $"{_parameters.WidthHooks * _parameters.AmtHooks + 150} мм)";
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
				MessageBox.Show("Проверьте правильность ввода данных", "Ошибка", MessageBoxButtons.OK,
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
