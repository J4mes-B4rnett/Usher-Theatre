[System.Serializable]
public abstract class Wants
{
     public string want;
     public int wantAmount;
     public int wantsUntilAction;

     public Wants(string want, int wantAmount, int wantsUntilAction)
     {
          this.want = want;
          this.wantAmount = wantAmount;
          this.wantsUntilAction = wantsUntilAction;
     }

     public abstract void ExecuteWant(Patron patron);
}
