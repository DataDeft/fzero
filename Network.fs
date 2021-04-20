namespace Fzero

open System.Collections.Generic


type Action = {
  Name: string
}


type NetworkOutput = {
  Value: float
  Reward: float
  PolicyLogits: Dictionary<Action,float>
  HiddenState: List<float>
}


type Network = {

  Name: string

} with

    member this.InitialInference (image) =
      { Value = 0.0; Reward = 0.0; PolicyLogits = new Dictionary<Action, float>() ; HiddenState = new List<float>()  }

    member this.RecurrentInference (hiddenState) (action) =
      { Value = 0.0; Reward = 0.0; PolicyLogits = new Dictionary<Action, float>() ; HiddenState = new List<float>()  }

    member this.GetWeights () =
      []

    member this.TrainingSteps () =
      0
