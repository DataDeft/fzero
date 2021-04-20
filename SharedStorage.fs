namespace Fzero


open System.Collections.Generic


type Network = {
  A : string
}


type SharedStorage = {
  Networks : Dictionary<int,Network>
  Optimizer : int
} with
    member this.LatestNetwork () =
      match this.Networks.Count with
      | 0 -> this.CreateUniformNetwork()
      | _ ->

        let last =
          this.Networks.Keys
          |> Seq.max

        this.Networks.Item(last)

    member this.CreateUniformNetwork () =
      { A  = "a" }

    member this.SaveNetwork (step) (network) =
      this.Networks.Add(step, network)


