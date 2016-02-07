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
        
        private List<int[,]> _moves;

        private int[,] _currentMove;

        private static Random _random = new Random();

        #endregion Fields

        #region Events

        public event EventHandler GameEnded;

        public void OnGameEnded()
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
            this.InitializeGameData();
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
            InitializeGameData();
            SetStartingMatrix(size);
            return _currentMove;
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

        private void InitializeGameData()
        {
            this._moves = new List<int[,]>();
            this._currentMove = null;
            this.Score = 0;
            this.Moves = 0;
        }

        private void SetStartingMatrix(int size)
        {
            int[,] newMatrix = new int[size, size];
            for (int i = 0; i < 2; i++)
            {
                AddRandomNumber(newMatrix, size);
            }
        }

        private void AddRandomNumber(int[,] matrix, int size)
        {
            int x = _random.Next(0, size);
            int y = _random.Next(0, size);

            matrix[x, y] = 2;
        }

        #endregion Private methods
    }
}
