using Nancy;
using FriendLetter.Objects;

namespace FriendLetter
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      // This is the way to manually set the variables to be the sender and recipients names
      Get["/"] = _ => {
        LetterVariables myLetterVariables = new LetterVariables();
        myLetterVariables.SetRecipient("Eric");
        myLetterVariables.SetSender("John");
        return View["hello.cshtml", myLetterVariables];
      };
      Get["/form"] = _ => {
        return View["form.cshtml"];
      };
      // This is getting names from a form and passing them to the other page
      Get["/greeting_card"] = _ => {
        LetterVariables myLetterVariables = new LetterVariables();
        myLetterVariables.SetRecipient(Request.Query["recipient"]);
        myLetterVariables.SetSender(Request.Query["sender"]);
        return View["hello.cshtml", myLetterVariables];
      };
    }
  }
}
