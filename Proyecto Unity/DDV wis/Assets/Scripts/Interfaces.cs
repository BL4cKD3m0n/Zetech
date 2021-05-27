interface IDamage
{
    void DoDamage(bool isPlayer);
}

interface PW_Ups //Ibox
{
    int getID();
    float GetEffects(); //Openbox
}

public enum PW_UpsID //BoxID
{
    VELOX2 = 0
}
