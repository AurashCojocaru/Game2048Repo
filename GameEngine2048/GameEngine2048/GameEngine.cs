using GameEngine2048.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine2048
{
    public class GameEngine : IGameEngine
    {
        #region Fields
        
        /// <summary>
        /// List of all the moves in the current game
        /// </summary>
        private List<int[,]> _moves;

        /// <summary>
        /// Current matrix
        /// </summary>
        private int[,] _currentMatrix;

        /// <summary>
        /// Random
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Size of current matrix.
        /// </summary>
        private int _size;

        #endregion Fields

        #region Events
        
        /// <summary>
        /// Triggers when there are no more moves that can be applied
        /// </summary>
        public event EventHandler GameEnded;

        /// <summary>
        /// Trigger for GameEnded event
        /// </summary>
        private void OnGameEnded()
        {
            if (GameEnded != null)
                GameEnded(this, EventArgs.Empty);
        }

        #endregion Events

        #region Constructors

        /// <summary>
        /// Gets an instance of GameEngine
        /// </summary>
        public GameEngine()
        {
            this.InitializeGameData(4);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets current score
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Gets current number of moves
        /// </summary>
        public int Moves { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Gets an initialized matrix of the given size with two random numbers in random positions.
        /// </summary>
        /// <param name="size">The size of the desired matrix.</param>
        /// <returns></returns>
        public int[,] StartGame(int size)
        {
            InitializeGameData(size);
            SetStartingMatrix();
            return _currentMatrix;
        }

        /// <summary>
        /// Applies the move to the current matrix and gets the resulting one.
        /// </summary>
        /// <param name="moveType">Move type.</param>
        /// <returns></returns>
        public int[,] ApplyMove(EMoveType moveType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the previous matrix that was created.
        /// </summary>
        /// <returns></returns>
        public int[,] Undo()
        {
            throw new NotImplementedException();
        }

        #endregion Public methods

        #region Private methods



        private void InitializeGameData(int size)
        {
            this._size = size;
            this._moves = new List<int[,]>();
            this._currentMatrix = null;
            this.Score = 0;
            this.Moves = 0;
        }

        private void SetStartingMatrix()
        {
            int[,] newMatrix = new int[_size, _size];
            for (int i = 0; i < 2; i++)
            {
                AddRandomNumberOnMatrix(newMatrix);
            }

            this._currentMatrix = newMatrix;
        }

        private void AddRandomNumberOnMatrix(int[,] matrix)
        {
            Position pos = GetRandomEmptyPosition(matrix);

            matrix[pos.X, pos.Y] = GetRandomNewNumber();
        }

        private int GetRandomNewNumber()
        {
            int newNumber = 2;
            double randomDouble = _random.NextDouble();
            if (randomDouble >= 0.75)
            {
                newNumber = 4;
            }
            return newNumber;
        }

        private Position GetRandomEmptyPosition(int[,] matrix)
        {
            List<Position> allAvailablePositions = GetAvailableSpaces(matrix);
            int randomIndex = _random.Next(0, allAvailablePositions.Count);
            return allAvailablePositions[randomIndex];
        }

        private List<Position> GetAvailableSpaces(int[,] matrix)
        {
            List<Position> result = new List<Position>();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Position pos = new Position(i, j);
                        result.Add(pos);
                    }
                }
            }            

            return result;
        }

        #endregion Private methods
    }
}
