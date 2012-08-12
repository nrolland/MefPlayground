module Class

open System.ComponentModel.Composition
open System.ComponentModel.Composition.Hosting


type Engine () = 
   member __.Start() = printfn "Starting Engine"
type Transmission () = 
   member __.Shiftup() = printfn "Gearing up!"
type Steering () = 
   member __.Left() = printfn "Going left "
type Brakes () = 
   member __.Stop() = printfn "Stopping car"

type CarDependent () = 
   let engine = Engine()
   let trans = Transmission()
   let steer = Steering()
   let brakes = Brakes()
   member __.Drive() = 
      engine.Start()
      trans.Shiftup()
      steer.Left()
      brakes.Stop()

[<AllowNullLiteral>]
type IEngine  = 
   abstract Start : unit -> unit
[<AllowNullLiteral>]
type ITransmission = 
   abstract Shiftup: unit -> unit
[<AllowNullLiteral>]
type ISteering  = 
   abstract  Left : unit -> unit
[<AllowNullLiteral>]
type IBrakes = 
   abstract Stop: unit -> unit

[<Export(typeof<IEngine>)>]
type CEngine () = 
   interface IEngine with
      member __.Start() = printfn "Starting Engine"
[<Export(typeof<ITransmission>)>]
type CTransmission () = 
   interface ITransmission with     
      member __.Shiftup() = printfn "Gearing up!"
[<Export(typeof<ISteering>)>]
type CSteering () = 
   interface ISteering with
      member __.Left() = printfn "Going left "
[<Export(typeof<IBrakes>)>]
type CBrakes () = 
   interface IBrakes with
      member __.Stop() = printfn "Stopping car"

type CarManaged () = 
   [<Import(typeof<IEngine>)>]
   let engine : IEngine = null
   [<Import(typeof<ITransmission>)>]
   let trans : ITransmission = null
   [<Import(typeof<ISteering>)>]
   let steer : ISteering= null
   [<Import(typeof<IBrakes>)>]
   let brakes : IBrakes= null
   member __.Drive() = 
      engine.Start()
      trans.Shiftup()
      steer.Left()
      brakes.Stop()


      
type IIngredient = 
   abstract Name : string
      
[<Export(typeof<IIngredient>)>]
type Bearnaise () =
   interface IIngredient with
      member __.Name = "ok"