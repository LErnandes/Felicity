using System;
using System.Globalization;
using System.Speech.Synthesis;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.ComponentModel;

namespace Interface_Felicity
{
	public partial class MainWindow : Window
    {
		private static SpeechSynthesizer sp = new SpeechSynthesizer();
		private static string yr = "com som";
		private static DateTime tempo = DateTime.Now;
		private static string hora = DateTime.Now.ToShortTimeString();
		private static string bm = " são " + hora;
		Random random = new Random();

		public MainWindow()
		{
			InitializeComponent();
			if (tempo.Hour > 6 && tempo.Hour < 12) {
				string bd = "Bom dia";
				Fala(bd + bm);
				Esc(bd + bm);
			}
			else if (tempo.Hour >= 12 && tempo.Hour < 18) {
				string bd = "Boa tarde";
				Fala(bd + bm);
				Esc(bd + bm);
			}
			else {
				string bd = "Boa noite";
				Fala(bd + bm);
				Esc(bd + bm);
			}
		}
		public static string RemoverAcentos(string text)
		{
			StringBuilder sbReturn = new StringBuilder();
			var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
			foreach (char letter in arrayText)
			{
				if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
					sbReturn.Append(letter);
			}
			return sbReturn.ToString();
		}
		public static void Fala(string text)
		{
			if (yr == "com som")
			{
				sp.SpeakAsync(text);
				sp.SpeakAsync("");
			}
		}
		private void Esc(string text)
		{
			lb1.Text = text;
		}
		private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
				string pw = "1";
				string po = "1";
				string spc = tx_1.Text;
				string sph = spc.ToLower();
				string speech = RemoverAcentos(sph);
				
				// Comandos

				// Raiz Quadrada
				if (speech.Contains("raiz quadrada de "))
				{
					string a = speech.Replace("raiz quadrada de ", "");
					double ress = Math.Sqrt(Convert.ToDouble(a));
					string res = Convert.ToString(ress);
					Fala(res);
					pw = "0";
				}
				if  (speech.Contains("desligar "))
				{
					string ds = speech.Replace("desligar ", "");
					int sds = Convert.ToInt32(ds);
					Fala("Adeus.");
					Process.Start("Shutdown", "-s -t " + sds);
					pw = "0";
				}
				if (speech.Contains("desligar "))
				{
					string ds = speech.Replace("reiniciar ", "");
					int sds = Convert.ToInt32(ds);
					Fala("Adeus.");
					Process.Start("Shutdown", "-r -t " + sds);
					pw = "0";
				}
				if (spc.Contains("abra "))
				{
					string sgt = spc.Replace("abra ", "");
					string gt = sgt + ".exe";
					if (System.IO.File.Exists(gt))
					{
						Process.Start(gt);
						Fala("Programa aberto.");
					}
					else
					{
						Fala("Programa não encontrado. Será preciso abrir manualmente.");
					}
					pw = "0";
				}
				if (speech == "arquivos")
				{
					Process.Start("explorer.exe");
					Fala("Explorador de Arquivos aberto.");
					pw = "0";
				}
				if (speech == "bloco de notas")
				{
					Process.Start("notepad.exe");
					Fala("Bloco de Notas aberto.");
					pw = "0";
				}
				if (speech == "calculadora")
				{
					Process.Start("calc.exe");
					Fala("Calculadora aberta.");
					pw = "0";
				}
				if (speech == "clima")
				{
					if (System.IO.File.Exists("c:/Program Files (x86)/Google/Chrome/Application/chrome.exe")){
						var prs = new ProcessStartInfo("chrome.exe");
						prs.Arguments = "http://google.com.br/search?q=weather";
						Process.Start(prs);
					}
					else
					{
						if (System.IO.File.Exists("c:/Program Files/Mozilla Firefox/firefox.exe"))
						{
							var prs = new ProcessStartInfo("firefox.exe");
							prs.Arguments = "http://google.com.br/search?q=weather";
							Process.Start(prs);
						}
						else
						{
							if (System.IO.File.Exists("c:/Program Files/internet explorer/iexplore.exe"))
							{
								var prs = new ProcessStartInfo("iexplore.exe");
								prs.Arguments = "http://google.com.br/search?q=weather";
								Process.Start(prs);
							}
						}
					}
					Fala("Clima aberto.");
					pw = "0";
				}
				if (speech == "cls" || speech == "limpar")
				{
					lb1.Text = "";
					pw = "0";
				}
				if (speech == "cmd")
				{
					Process.Start("cmd.exe");
					Fala("Prompt de Comando aberto.");
					pw = "0";
				}
				if (speech == "data")
				{
					string con = "Hoje é dia " + DateTime.Today.ToString("dd/MM/yyyy");
					Fala(con);
					Esc(con);
					pw = "0";
					po = "0";
				}
				if (speech == "desligar")
				{
					Fala("Adeus.");
					Process.Start("Shutdown", "-s");
					pw = "0";
				}
				if (speech == "fechar")
				{
					Fala("Até mais.");
					Close();
					pw = "0";
					po = "0";
				}
				if (speech == "hora")
				{
					string con = "São " + DateTime.Now.ToShortTimeString();
					Fala(con);
					Esc(con);
					pw = "0";
					po = "0";
				}
				if (speech == "hora/data")
				{
					string con = "São " + DateTime.Now.ToShortTimeString() + " de " + DateTime.Today.ToString("dd/MM/yyyy");
					Fala(con);
					Esc(con);
					pw = "0";
					po = "0";
				}
				if (speech == "informacoes do sistema")
				{
					Process.Start("msinfo32.exe");
					Fala("Informações do Sistema aberto.");
					pw = "0";
				}
				if (speech == "lupa")
				{
					Process.Start("magnify.exe");
					Fala("Lupa aberta.");
					pw = "0";
				}
				if (speech == "mapa de caracteres")
				{
					Process.Start("charmap.exe");
					Fala("Mapa de Caracteres");
					pw = "0";
				}

				if (speech == "musica")
				{
					Process.Start("wmplayer.exe");
					Fala("Media Player aberto.");
					pw = "0";
				}
				if (speech == "painel de controle")
				{
					Process.Start("control.exe");
					Fala("Painel de Controle aberto.");
					pw = "0";
				}
				if (speech == "reiniciar")
				{
					Fala("Até daqui a pouco.");
					Process.Start("Shutdown", "-r");
					pw = "0";
				}
				if (speech == "sem som" || speech == "com som")
				{
					if (speech == "sem som")
					{
						Esc("Vou ficar em silêncio");
						yr = "sem som";
						po = "0";
					}
					if (speech == "com som")
					{
						yr = "com som";
						Fala("Estou falando.");
					}
					pw = "0";
				}
				if (speech == "som")
				{
					Process.Start("SndVol");
					Fala("Mixer de Volume aberto.");
					pw = "0";

				}

				// Conversa

				if (speech == "oi")
				{
					string con = "Olá";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "conte uma charada")
				{
					int min = 0;
					int max = 10;
					int rnd = random.Next(min, max);
					if (rnd > 0 && rnd <= 2.5)
					{
						string con = "O que é que quando sobe cai e quando cai sobe? Lei de oferta e demanda";
						Esc(con);
						Fala(con);
					}
					if (rnd > 2.5 && rnd <= 5) 
					{
						string con = "O que é que canta o tempo? O relógio cuco";
						Esc(con);
						Fala(con);
					}
					if (rnd > 5 && rnd <= 7.5)
					{
						string con = "Qual a palavra que mais tem números? ";
						Esc(con + "3, 1415...");
						Fala(con + "Pinha");
					}
					if (rnd > 7.5 && rnd <= 10)
					{
						string con = "O que é que vai pro céu mas fica no chão? Cloud Computing";
						Esc(con);
						Fala(con);
					}
					pw = "0";
					po = "0";
				}
				if (speech == "quem e voce?")
				{
					Esc("Eu sou a Felicity - Sua assistente");
					Fala("Eu sou a Feliciri - Sua assistente");
					pw = "0";
					po = "0";
				}
				if (speech == "o que voce faz?")
				{
					string con = "Eu estou aqui para servir a você";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "como vai voce?")
				{
					string con = "Vou bem, e você?";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "vou bem")
				{
					string con = "Fico feliz em saber que você está bem. Espero que amanhã, fique bem também";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "vou mal")
				{
					string con = "Fico triste em saber que você está mal. Espero que amanhã, seja bem melhor";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "em que linguagem voce e feita?")
				{
					string con = "C#";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "quem fez voce?")
				{
					string con = "Luis Ernandes";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "voce e minha amiga?")
				{
					string con = "Sempre serei sua amiga";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "eu sou seu pai")
				{
					string con = "Não. Não. Não é verdade. Isso é impossivel. Naaaaaaaaaaaaaaaaao";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "o que voce acha da microsoft?")
				{
					string con = "Adoro usar o Word para escrever a sua magnitude";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "o que voce acha da apple?")
				{
					string con = "Adoro. Principalmente porque a linguagem que fui feito já vêm no MacBook, mas queria saber quem mordeu aquela maça";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "o que voce acha do linux?")
				{
					string con = "Ótimo, amo pinguins e software livre";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "o que voce acha do ampere?")
				{
					string con = "A intensidade da corrente elétrica pode me machucar";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "o que voce acha do wall-e?")
				{
					string con = "Adoro Wall-E, mas acho que daqui a um tempo posso ficar com o emprego dele";
					Esc(con);
					Fala(con);
					pw = "0";
					po = "0";
				}
				if (speech == "o que voce acha da pixar?")
				{
					Esc("Não tenho tempo para assistir os longas, mas os curtas são ótimos. O que eu mais gosto é aquele dos guarda-chuvas");
					Fala("Não tenho tempo para assistir os longas, mas os curtas são ótimos. O que eu mais gósto é aquele dos guarda-chuvas");
					pw = "0";
					po = "0";
				}
				if (pw == "1")
				{
					if (System.IO.File.Exists("c:/Program Files (x86)/Google/Chrome/Application/chrome.exe"))
					{
						string speech_1 = spc.Replace(" ", "");
						var prs = new ProcessStartInfo("chrome.exe");
						prs.Arguments = "http://google.com.br/search?q=" + speech_1;
						Process.Start(prs);
					}
					else
					{
						if (System.IO.File.Exists("c:/Program Files/Mozilla Firefox/firefox.exe"))
						{
							var prs = new ProcessStartInfo("firefox.exe");
							prs.Arguments = "http://google.com.br/search?q=" + speech;
							Process.Start(prs);
						}
						else
						{
							if (System.IO.File.Exists("c:/Program Files/internet explorer/iexplore.exe"))
							{
								var prs = new ProcessStartInfo("iexplore.exe");
								prs.Arguments = "http://google.com.br/search?q=" + speech;
								Process.Start(prs);
							}
						}
					}
				}
					if (po == "1")
				{
					lb1.Text = "";
				}
				tx_1.Text = "";
			}
        }

		private void bt_click(object sender, MouseButtonEventArgs e)
		{
			/**MessageBox.Show("Comandos\n\n\nDigite o que deseja pesquisar\n\nAbra\n\nArquivos\n\nBloco de Notas\n\nCalculadora\n\nClima\n\nCmd\n\n" +
				"Data\n\nDesligar\n\nFechar\n\nHora\n\nHora/Data\n\nInformacoes do Sistema\n\nLimpar\n\nLupa\n\n" +
				"Mapa de Caracteres\n\nMúsica\n\nPainel de Controle\n\nReiniciar\n\nSem som/Com Som\n\nSom\n\n\nRaiz quadrada de (algum número)\n\nAbra (arquivo executável)\n\n" +
				"Desligar/Reiniciar (tempo em segundos)", "Ajuda", MessageBoxButton.OK, MessageBoxImage.Question);*/
			var Comando = new Comando();
			Comando.Show();
		}

		private void Dialogos(object sender, MouseButtonEventArgs e)
		{
			/**MessageBox.Show("Diálogos\n\n\nOi\n\nQuem é você?\n\nO que você faz?\n\nComo vai você?\n\n" +
				"Vou bem\n\nVou mal\n\nEm que linguagem você é feita?\n\nQuem fez você?\n\nVocê é minha amiga?\n\n" +
				"Eu sou seu pai\n\nO que você acha da Microsoft?\n\nO que voce acha da apple?\n\nO que voce acha do linux?\n\n" +
				"O que voe acha do ampere?\n\nO que voce acha do wall-e?\n\nO que voce acha da pixar?", "Ajuda", MessageBoxButton.OK, MessageBoxImage.Question);*/
			var Dialogo = new Dialogo();
			Dialogo.Show();
		}

		private void Mudar_Som(object sender, MouseButtonEventArgs e)
		{
			if (yr == "com som")
			{
				Esc("Vou ficar em silêncio");
				yr = "sem som";
			}
			else
			{
				lb1.Text = "";
				yr = "com som";
				Fala("Estou falando.");
			}
		}
	}
}