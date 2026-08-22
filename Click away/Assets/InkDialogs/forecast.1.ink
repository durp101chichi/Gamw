VAR name = "???"
VAR work = "???"

-> Begin
=== Begin
grghhh #anim:forecast_drink #char:{name}
 + [hello?] -> Start
 + [...] -> Begin

=== Start
hm? #anim:forecast_drink #char:{name}
who are you?

Click #anim:click_confused #char:Click

hmmmmmmm #anim:forecast_norm #char:{name}
so, you the guy for the job.. kind of.. small
 + [wha?] -> Continue
 + [and?] -> YouSure
=== YouSure
I mean, you sure you can do it? it's a big boy job #anim:forecast_think #char:{name}
 + [and?] -> Continue
 + [yes] -> Help
 + [>:(] -> Angry
 
 === Angry
 How dare you.. #anim:click_confused #char:Click
 ...
 Bet your drunk cloud would run to its mother board if you had to do it. #char:Click #anim:click_hah
 EH?!? #anim:forecast_wow #char:{name}
 ..
 ...
 .....
 -> Continue
 
 === Help
 if you say so... #anim:forecast_norm #char:{name}
 ->Continue
 
 === Continue
 ... #anim:forecast_norm #char:{name}
welp, uh, here is your ticket, go, shoo #anim:forecast_think #char:{name}
+ [job?] -> Job
+ [okay] -> END
+ [wha?] -> Job
+ [who r u?] -> Work

=== Work
~name = "Forecast"
my name is Forecast, I am your boss, so go work#anim:forecast_think #char:{name}
{ work == "work": -> Okay | -> answerJob}

=== Job
~work = "work"
did you NOT read the job description and just TOOK IT? #anim:forecast_wow #char:{name}
the economy isn't THAT BAD
eh, worse for you#anim:forecast_think #char:{name}
you'r job is simple, head over to the train station and give your ticket to the blue bird man
he will get you to a shared space of the conspiracy, there, collect info on the people connected to the reported problem
{ name == "Forecast": -> Okay | -> answerName}

=== answerJob
+ [job?] -> Job
+ [okay] -> END
=== answerName
+ [who r u?] -> Work
+ [okay] -> END
=== Okay
+ [okay] -> END
