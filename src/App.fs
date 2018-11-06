module ReactTest

open Fable.Core.JsInterop
open Elmish
open Elmish.React

importAll "../scss/main.scss"

open Movies.State
open Movies.View

// App
Program.mkSimple initState update root
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReact "app"
|> Program.run