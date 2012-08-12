module Test

open Xunit
open System
open Swensen.Unquote
open System.ComponentModel.Composition
open System.ComponentModel.Composition.Hosting

open Class

[<Fact>]
let ``mef works`` () = 
   use cat = new TypeCatalog(typeof<Bearnaise>)
   use container = new CompositionContainer(cat)
   let sauce = container.GetExportedValue<IIngredient>()
   let n = sauce.Name
   printfn "sauce %A" sauce
   test <@ sauce.Name = "ok" @>


[<Fact>]
let ``car has dependencies that need to be provided to work `` () = 
   let c = CarManaged()
   raises<NullReferenceException> <@ c.Drive() @>

[<Fact>]
let ``car can be built`` () = 
   let c = CarManaged()

   use cat =  new TypeCatalog([ typeof<CEngine>;  typeof<CTransmission>;  typeof<CSteering>;  typeof<CBrakes>])
   use container = new CompositionContainer(cat)
   container.ComposeParts(c)

   test  <@ c.Drive() = ()  @>


