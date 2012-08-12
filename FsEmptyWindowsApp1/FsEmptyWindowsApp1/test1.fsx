#if INTERACTIVE
#load @"__solmerged.fsx"
#endif


open Xunit
open Swensen.Unquote
open System.ComponentModel.Composition
open System.ComponentModel.Composition.Hosting

open Class

use cat =  new TypeCatalog([ typeof<CEngine>;  typeof<CTransmission>;  typeof<CSteering>;  typeof<CBrakes>])
use container = new CompositionContainer(cat)
let c = CarManaged()
c.Drive()

container.ComposeParts(c)
c.Drive()
