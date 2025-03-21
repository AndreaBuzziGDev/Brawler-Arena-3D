public enum SoundPlaybackMode
{
    Normal,        //NO LIMITATION
    RateLimited,   //LIMITED RATE
    AmountLimited, //CAN HAVE MORE THAN ONE INSTANCE, BUT IS SUPPOSED TO HAVE A MAX RATE
    UniqueInstance //ONLY ONE OF THIS SOUND AT A TIME
}
