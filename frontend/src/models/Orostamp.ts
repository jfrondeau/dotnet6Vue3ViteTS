import IOroStamp from "./IOroStamp"

export default class OroStamp {
  public id: number = 0
  public userId: number = 0
  public punchAt: Date = new Date()
  public isIn: Boolean = true

  // protected static SInit = (() => {
  //   OroStamp.prototype.id = 0
  //   OroStamp.prototype.userId = 0
  //   OroStamp.prototype.punchAt = new Date()
  // })()

  // constructor(data: IOroStamp) {
  //   this.id = data.id
  //   this.userId = data.userId
  //   this.punchAt = new Date(data.punchAt)
  //   this.isIn = data.isIn
  // }
}
