namespace Fzero


open System.Collections.Generic


type Network = {
  A : string
}


type SharedStorage = {
  Networks : Dictionary<int,Network>
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



// class SharedStorage(object):

//   def __init__(self):
//     self._networks = {}

//   def latest_network(self) -> Network:
//     if self._networks:
//       return self._networks[max(self._networks.keys())]
//     else:
//       # policy -> uniform, value -> 0, reward -> 0
//       return make_uniform_network()

//   def save_network(self, step: int, network: Network):
//     self._networks[step] = network

