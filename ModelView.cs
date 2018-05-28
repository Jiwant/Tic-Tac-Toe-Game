using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe
{
	class ViewModel : INotifyPropertyChanged
	{
		//Declaring Constants
		const int MAX_ROW = 3;
		const int MAX_COL = 3;
		const int INIT_ROW = 1;
		const int INIT_COL = 1;
		const int ZERO_VAL = 0;
		const int ONE_VAL = 1;

		public const int FIRST_ROW = 1;
		public const int SECOND_ROW = 2;
		public const int THIRD_ROW = 3;
		public const int FIRST_COL = 1;
		public const int SECOND_COL = 2;
		public const int THIRD_COL = 3;

		//Declaring Binding Variables
		bool symbolXChk = false;
		bool symbolXEn = true;
		bool symbolOChk = false;
		bool symbolOEn = true;
		int numberOfRounds = 1;
		bool numberOfRoundsEn = true;
		bool startEn = true;
		bool resetEn = false;
		string playerTurn = "";
		string opt11 = "";
		bool opt11En = false;
		string opt12 = "";
		bool opt12En = false;
		string opt13 = "";
		bool opt13En = false;
		string opt21 = "";
		bool opt21En = false;
		string opt22 = "";
		bool opt22En = false;
		string opt23 = "";
		bool opt23En = false;
		string opt31 = "";
		bool opt31En = false;
		string opt32 = "";
		bool opt32En = false;
		string opt33 = "";
		bool opt33En = false;
		string result = "";
		bool nextRoundEn = false;
		string player1sym = "O";
		string player2sym = "X";

		//Using ENUM for Player
		public enum Player
		{
			Player1 = 1,
			Player2
		};

		bool[,] p1rr = new bool[3, 3];//Player 1 Round Record
		bool[,] p2rr = new bool[3, 3];//Player 2 Round Record

		//Varialbe Storing Current Turn
		Player Turn=Player.Player1;
		
		//Variable to Store Count of Turns
		int turnCount = ZERO_VAL;

		//Variable to Store Count of Rounds
		int roundCount = ZERO_VAL;

		//To Store the Game Records for different Rounds
		Dictionary<int, RoundRecord> GameRecord = new Dictionary<int, RoundRecord>();

		public bool SymbolXChk
		{
			get { return symbolXChk; }
			set { symbolXChk = value; OnPropertyChanged(); }
		}

		public bool SymbolXEn
		{
			get { return symbolXEn; }
			set { symbolXEn = value; OnPropertyChanged(); }
		}

		public bool SymbolOChk
		{
			get { return symbolOChk; }
			set { symbolOChk = value; OnPropertyChanged(); }
		}

		public bool SymbolOEn
		{
			get { return symbolOEn; }
			set { symbolOEn = value; OnPropertyChanged(); }
		}

		public String NumberOfRounds
		{
			get { return numberOfRounds.ToString() ; }
			set { numberOfRounds = int.Parse(value); OnPropertyChanged(); }
		}

		public bool NumberOfRoundsEn
		{
			get { return numberOfRoundsEn; }
			set { numberOfRoundsEn = value; OnPropertyChanged(); }
		}

		public bool StartEn
		{
			get { return startEn; }
			set { startEn = value; OnPropertyChanged(); }
		}

		public bool ResetEn
		{
			get { return resetEn; }
			set { resetEn = value; OnPropertyChanged(); }
		}

		public String PlayerTurn
		{
			get { return playerTurn; }
			set { playerTurn = value; OnPropertyChanged(); }
		}

		public String Opt11
		{
			get { return opt11; }
			set { opt11 = value; OnPropertyChanged(); }
		}

		public bool Opt11En
		{
			get { return opt11En; }
			set { opt11En = value; OnPropertyChanged(); }
		}

		public String Opt12
		{
			get { return opt12; }
			set { opt12 = value; OnPropertyChanged(); }
		}

		public bool Opt12En
		{
			get { return opt12En; }
			set { opt12En = value; OnPropertyChanged(); }
		}

		public String Opt13
		{
			get { return opt13; }
			set { opt13 = value; OnPropertyChanged(); }
		}

		public bool Opt13En
		{
			get { return opt13En; }
			set { opt13En = value; OnPropertyChanged(); }
		}

		public String Opt21
		{
			get { return opt21; }
			set { opt21 = value; OnPropertyChanged(); }
		}

		public bool Opt21En
		{
			get { return opt21En; }
			set { opt21En = value; OnPropertyChanged(); }
		}

		public String Opt22
		{
			get { return opt22; }
			set { opt22 = value; OnPropertyChanged(); }
		}

		public bool Opt22En
		{
			get { return opt22En; }
			set { opt22En = value; OnPropertyChanged(); }
		}

		public String Opt23
		{
			get { return opt23; }
			set { opt23 = value; OnPropertyChanged(); }
		}

		public bool Opt23En
		{
			get { return opt23En; }
			set { opt23En = value; OnPropertyChanged(); }
		}

		public String Opt31
		{
			get { return opt31; }
			set { opt31 = value; OnPropertyChanged(); }
		}

		public bool Opt31En
		{
			get { return opt31En; }
			set { opt31En = value; OnPropertyChanged(); }
		}

		public String Opt32
		{
			get { return opt32; }
			set { opt32 = value; OnPropertyChanged(); }
		}

		public bool Opt32En
		{
			get { return opt32En; }
			set { opt32En = value; OnPropertyChanged(); }
		}

		public String Opt33
		{
			get { return opt33; }
			set { opt33 = value; OnPropertyChanged(); }
		}

		public bool Opt33En
		{
			get { return opt33En; }
			set { opt33En = value; OnPropertyChanged(); }
		}

		public String Result
		{
			get { return result; }
			set { result = value; OnPropertyChanged(); }
		}
		
		public bool NextRoundEn
		{
			get { return nextRoundEn; }
			set { nextRoundEn = value; OnPropertyChanged(); }
		}

		//Method to Start the Game Process
		public void GameStart()
		{
			player1sym = (SymbolOChk ? "O" : "X");
			player2sym = (SymbolOChk ? "X" : "O");
			SymbolOEn = false;
			SymbolXEn = false;
			NumberOfRoundsEn = false;
			resetEn = false;
			PlayerTurn = "Player 1";
			for(int i=INIT_ROW;i<=MAX_ROW;i++)
				for(int j=INIT_COL;j<=MAX_COL;j++)
				{
					Opt(i, j, "", true);
					p1rr[i - 1, j - 1] = false;
					p2rr[i - 1, j - 1] = false;
				}
			Result = "";
			NextRoundEn = false;
			Turn = Player.Player1;
			turnCount = ZERO_VAL;
			roundCount = ONE_VAL;
			GameRecord.Clear();
		}

		//Method to Reset the Game
		public void TotalReset()
		{
			SymbolOEn = true;
			SymbolXEn = true;
			NumberOfRoundsEn = true;
			resetEn = true;
			PlayerTurn = "";
			for (int i = INIT_ROW; i <= MAX_ROW; i++)
				for (int j = INIT_COL; j <= MAX_COL; j++)
				{
					Opt(i, j, "", false);
					p1rr[i - 1, j - 1] = false;
					p2rr[i - 1, j - 1] = false;
				}
			Result = "";
			NextRoundEn = false;
			Turn = Player.Player1;
			turnCount = ZERO_VAL;
			roundCount = ZERO_VAL;
			GameRecord.Clear();
		}

		//Method to Facilitate Player Operation
		public void SelectOption(int i,int j)
		{
			turnCount++;
			PlayerTurn = (Turn == Player.Player1) ? "Player 2" : "Player 1";
			if (turnCount < ( MAX_ROW * MAX_COL ) )
			{
				if (Turn == Player.Player1)
				{
					p1rr[i - 1, j - 1] = true;
					Opt(i, j, player1sym, false);
					if (WinCheck())
					{

						PlayerTurn = "Player";
						GameRecord.Add(roundCount,new RoundRecord(true,false));

						if (roundCount == numberOfRounds)
						{
							Result=GameResult();
							for (i = INIT_ROW; i <= MAX_ROW; i++)
								for (j = INIT_COL; j <= MAX_COL; j++)
									OptEn(i, j, false);
							NextRoundEn = false;
							ResetEn = true;
						}
						else
						{
							Result = "Player 1 Wins the Round";
							for (i = INIT_ROW; i <= MAX_ROW; i++)
								for (j = INIT_COL; j <= MAX_COL; j++)
									OptEn(i, j, false);
							NextRoundEn = true;
						}
					}

					else
					{

						Turn = Player.Player2;
					}
				}

				else if (Turn == Player.Player2)
				{
					p2rr[i - 1, j - 1] = true;
					Opt(i, j, player2sym, false);
					if (WinCheck())
					{

						GameRecord.Add(roundCount, new RoundRecord(false, true));

						if (roundCount == numberOfRounds)
						{
							Result = GameResult();
							for (i = INIT_ROW; i <= MAX_ROW; i++)
								for (j = INIT_COL; j <= MAX_COL; j++)
									OptEn(i, j, false);
							NextRoundEn = false;
							ResetEn = true;
						}
						else
						{
							Result = "Player 2 Wins the Round";
							for (i = INIT_ROW; i <= MAX_ROW; i++)
								for (j = INIT_COL; j <= MAX_COL; j++)
									OptEn(i, j, false);
							NextRoundEn = true;
						}
					}

					else
					{
						Turn = Player.Player1;
					}
				}
			}

			else
			{
				string str = (Turn == Player.Player1) ? "player2sym" : "player1sym";
				Opt(i, j, str, false);
				GameRecord.Add(roundCount, new RoundRecord(false, false));
				if (roundCount == numberOfRounds)
				{
					Result = GameResult();
					NextRoundEn = false;
					ResetEn = true;
				}

				else
				{
					Result = "Round is a Draw";
					NextRoundEn = true;
				}
			}
		}

		//Method to Check the Winner
		public bool WinCheck()
		{
			bool resultInt=false;
			if (Turn==Player.Player1)
			{
				resultInt = (p1rr[0, 0] && p1rr[0, 1] && p1rr[0, 2]) ||
							(p1rr[1, 0] && p1rr[1, 1] && p1rr[1, 2]) ||
							(p1rr[2, 0] && p1rr[2, 1] && p1rr[2, 2]) ||
							(p1rr[0, 0] && p1rr[1, 0] && p1rr[2, 0]) ||
							(p1rr[0, 1] && p1rr[1, 1] && p1rr[2, 1]) ||
							(p1rr[0, 2] && p1rr[1, 2] && p1rr[2, 2]) ||
							(p1rr[0, 0] && p1rr[1, 1] && p1rr[2, 2]) ||
							(p1rr[2, 0] && p1rr[1, 1] && p1rr[0, 2]);
			}

			else if(Turn==Player.Player2)
			{
				resultInt = (p2rr[0, 0] && p2rr[0, 1] && p2rr[0, 2]) ||
							(p2rr[1, 0] && p2rr[1, 1] && p2rr[1, 2]) ||
							(p2rr[2, 0] && p2rr[2, 1] && p2rr[2, 2]) ||
							(p2rr[0, 0] && p2rr[1, 0] && p2rr[2, 0]) ||
							(p2rr[0, 1] && p2rr[1, 1] && p2rr[2, 1]) ||
							(p2rr[0, 2] && p2rr[1, 2] && p2rr[2, 2]) ||
							(p2rr[0, 0] && p2rr[1, 1] && p2rr[2, 2]) ||
							(p2rr[2, 0] && p2rr[1, 1] && p2rr[0, 2]);
			}

			return resultInt;
		}

		//Method to Store Game Result
		public string GameResult()
		{
			int player1Wins = ZERO_VAL, player2Wins = ZERO_VAL, i = ZERO_VAL;
			string resultInt = "";
			for(i=1;i<=numberOfRounds;i++)
			{
				
				player1Wins += GameRecord[i].Player1Win;
			}

			for(i=1;i<=numberOfRounds;i++)
			{
				player2Wins += GameRecord[i].Player2Win;
			}

			if (player1Wins == player2Wins)
			{
				resultInt = "Game is Draw";
			}

			else
			{
				if (player1Wins > player2Wins)
				{
					resultInt = "Player 1 Wins the Game";
				}

				else
				{
					resultInt = "Player 2 Wins the Game";
				}
			}

			return resultInt;
		}

		//Method to go to Next Round
		public void NextRound()
		{
			RoundReset();
		}

		public void RoundReset()
		{
			PlayerTurn="Player 1";
			for (int i = INIT_ROW; i <= MAX_ROW; i++)
				for (int j = INIT_COL; j <= MAX_COL; j++)
				{
					Opt(i, j, "", true);
					p1rr[i - 1, j - 1] = false;
					p2rr[i - 1, j - 1] = false;
				}
			Result = "";
			Turn = Player.Player1;
			++roundCount;
			turnCount = ZERO_VAL;
		}

		//Method to Give Indexed Nature to variables
		public void Opt(int i, int j, string str, bool val)
		{
			if (i == FIRST_ROW)
			{
				if (j == FIRST_COL)
				{
					Opt11 = str;
					Opt11En = val;
				}

				else if (j == SECOND_COL)
				{
					Opt12 = str;
					Opt12En = val;
				}

				else if (j == THIRD_COL)
				{
					Opt13 = str;
					Opt13En = val;
				}
			}

			else if (i == SECOND_ROW)
			{
				if (j == FIRST_COL)
				{
					Opt21 = str;
					Opt21En = val;
				}

				else if (j == SECOND_COL)
				{
					Opt22 = str;
					Opt22En = val;
				}

				else if (j == THIRD_COL)
				{
					Opt23 = str;
					Opt23En = val;
				}
			}

			else if (i == THIRD_ROW)
			{
				if (j == FIRST_COL)
				{
					Opt31 = str;
					Opt31En = val;
				}

				else if (j == SECOND_COL)
				{
					Opt32 = str;
					Opt32En = val;
				}

				else if (j == THIRD_COL)
				{
					Opt33 = str;
					Opt33En = val;
				}
			}
		}
			//Method to give Indexed Nature to Variables
			public void OptEn(int i, int j, bool val)
			{
				if (i == FIRST_ROW)
				{
					if (j == FIRST_COL)
					{
						Opt11En = val;
					}

					else if (j == SECOND_COL)
					{
						Opt12En = val;
					}

					else if (j == THIRD_COL)
					{
						Opt13En = val;
					}
				}

				else if (i == SECOND_ROW)
				{
					if (j == FIRST_COL)
					{
						Opt21En = val;
					}

					else if (j == SECOND_COL)
					{
						Opt22En = val;
					}

					else if (j == THIRD_COL)
					{
						Opt23En = val;
					}
				}

				else if (i == THIRD_ROW)
				{
					if (j == FIRST_COL)
					{
						Opt31En = val;
					}

					else if (j == SECOND_COL)
					{
						Opt32En = val;
					}

					else if (j == THIRD_COL)
					{
						Opt33En = val;
					}
				}
			}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] String propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
