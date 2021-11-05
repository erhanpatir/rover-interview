using MarsRover.Models;

namespace MarsRover.States
{
    /// <summary>
    /// interface of management of State.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// defines orientation of state.
        /// </summary>
        string Code { get; }
        void TurnRight(Rover rover);
        void TurnLeft(Rover rover);
        void Move(Rover rover);
        void Stop(Rover rover);
    }
}
