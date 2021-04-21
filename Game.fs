namespace Fzero


type Game = {
  History: int list
  Rewards: int list
  ChildVisits: int list
  RootValues: int list
  Discount: float
}

[<AbstractClass>]
type IGame =

  //
  abstract Apply: action: int -> game: Game -> Game
  abstract LegalActions: game: Game  -> int []
  abstract StoreSearchStatistics: root: Node -> unit
  abstract MakeTarget: stateInde: int -> numUnrollSteps: int -> tdSteps: int -> toPlay: Player -> int []
  abstract ToPlay: unit -> Player
  abstract ActionHistory: unit -> unit

  default this.Apply (action:int) (game:Game) =
    // Apply an action onto the environment.
    let reward = this.Step action game

    {
      History = game.History; Rewards = (reward :: game.Rewards);
      ChildVisits = game.ChildVisits; RootValues = game.RootValues;
      Discount = game.Discount
     }
  //


  abstract Step: action: int -> game: Game -> int
