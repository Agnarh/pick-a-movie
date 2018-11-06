module ReactTest

open Fable.Core.JsInterop
open Elmish
open Elmish.React

importAll "../scss/main.scss"

open Movies.State
open Movies.View
open Movies.DataAccess

// App
Program.mkSimple (loadState >> initState) updateState root
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReact "app"
|> Program.run