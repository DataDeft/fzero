namespace Fzero

type MinMaxStats = {
  Min : float
  Max : float
} with
  member this.DefaultMinMax() =
    { Min =  +infinity; Max = -infinity }

type MuZeroConfigDefaults = {
  Ver: string
} with
  // default values
  member this.DefaultRootExplorationFraction  = 0.25
  member this.DefaultPbCBase                  = uint32(19652)
  member this.DefaultPbCInit                  = 1.25
  member this.DefaultTrainingSteps            = uint32(1_000_000)
  member this.DefaultCheckpointInterval       = uint32(1_000)
  member this.DefaultWindowSize               = uint32(1_000_000)
  member this.DefaultNumUnrollSteps           = uint32(5)
  member this.DefaultWeightDecay              = float(0.0001)
  member this.DefaultMomentum                 = float(0.9)
  member this.DefaultLrDecayRate              = float(0.1)
  member this.DefaultLRDecaySteps             = float(400000.0)
  member this.DefaultDiscount                 = float(1.0)
  member this.DefaultNumSimulations           = uint32(800)
  member this.DefaultBatchSize                = uint32(2048)
  member this.DefaultNumActors                = uint32(3000)

  member this.DefaultVisitSoftmaxTemperature (numMoves:int) (trainingSteps:int) : float =
    match numMoves with
    | numMoves when numMoves < 30 -> 1.0
    | _ -> 1.0

type MuZeroConfig = {

  Name: string

  // basic fields
  ActionSpaceSize: uint32
  MaxMoves: uint32
  Discount: float
  DirichletAlpha: float
  NumSimulations: uint32
  BatchSize: uint32
  TdSteps: uint32
  NumActors: uint32
  LRInit: float
  LRDecaySteps: float
  VisitSoftmaxTemperatureFn: (int -> int -> float)
  KnownBounds: Option<MinMaxStats>

  // advanced fields
  RootDirichletAlpha: float
  RootExplorationFraction: float
  PbCBase: uint32
  PbCInit: float
  TrainingSteps: uint32
  CheckpointInterval: uint32
  WindowSize: uint32
  NumUnrollSteps: uint32
  WeightDecay: float
  Momentum: float
  LrDecayRate: float

} with
  member this.GetGoConfig() =
    let defaults = { Ver = "2021-04-01" }
    {
      Name                      = "Go"
      ActionSpaceSize           = uint32(362)
      MaxMoves                  = uint32(722)
      Discount                  = defaults.DefaultDiscount
      DirichletAlpha            = float(0.03)
      NumSimulations            = defaults.DefaultNumSimulations
      BatchSize                 = defaults.DefaultBatchSize
      TdSteps                   = uint32(722)
      NumActors                 = defaults.DefaultNumActors
      LRInit                    = float(0.01)
      LRDecaySteps              = defaults.DefaultLRDecaySteps
      VisitSoftmaxTemperatureFn = defaults.DefaultVisitSoftmaxTemperature
      KnownBounds               = Some { Min = -1.0;  Max = 1.0 }
      RootDirichletAlpha        = float(0.03)
      RootExplorationFraction   = defaults.DefaultRootExplorationFraction
      PbCBase                   = defaults.DefaultPbCBase
      PbCInit                   = defaults.DefaultPbCInit
      TrainingSteps             = defaults.DefaultTrainingSteps
      CheckpointInterval        = defaults.DefaultCheckpointInterval
      WindowSize                = defaults.DefaultWindowSize
      NumUnrollSteps            = defaults.DefaultNumUnrollSteps
      WeightDecay               = defaults.DefaultWeightDecay
      Momentum                  = defaults.DefaultMomentum
      LrDecayRate               = defaults.DefaultLrDecayRate
    }
    member this.GetChessConfig() =
      let defaults = { Ver = "2021-04-01" }
      {
        Name                      = "Chess"
        ActionSpaceSize           = uint32(4672)
        MaxMoves                  = uint32(512)
        Discount                  = defaults.DefaultDiscount
        DirichletAlpha            = float(0.3)
        NumSimulations            = defaults.DefaultNumSimulations
        BatchSize                 = defaults.DefaultBatchSize
        TdSteps                   = uint32(512)
        NumActors                 = defaults.DefaultNumActors
        LRInit                    = float(0.1)
        LRDecaySteps              = defaults.DefaultLRDecaySteps
        VisitSoftmaxTemperatureFn = defaults.DefaultVisitSoftmaxTemperature
        KnownBounds               = Some { Min = -1.0;  Max = 1.0 }
        RootDirichletAlpha        = float(0.3)
        RootExplorationFraction   = defaults.DefaultRootExplorationFraction
        PbCBase                   = defaults.DefaultPbCBase
        PbCInit                   = defaults.DefaultPbCInit
        TrainingSteps             = defaults.DefaultTrainingSteps
        CheckpointInterval        = defaults.DefaultCheckpointInterval
        WindowSize                = defaults.DefaultWindowSize
        NumUnrollSteps            = defaults.DefaultNumUnrollSteps
        WeightDecay               = defaults.DefaultWeightDecay
        Momentum                  = defaults.DefaultMomentum
        LrDecayRate               = defaults.DefaultLrDecayRate
      }

module MuZero =

  let echo =  1
