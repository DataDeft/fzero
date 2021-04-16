namespace Fzero

type Player =
  X | O


type TicTacToeAtom =
  Filled of Player | Empty


type TicTacToeState = TicTacToeAtom[]


type Action =
  Action of uint8 | IllegalAction
  with
  static member Create (num : int) : Action =
    match num with
    | ok when ok < 9 && ok >= 0 -> Action (uint8(ok))
    | _ -> IllegalAction


type Step =
  {
    Board: TicTacToeState
    Player: Player
    GameWonBy: option<Player>
    Reward: int
  }
