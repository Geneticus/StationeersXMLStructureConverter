using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StationeersStructureXMLConverter
{
    public class SaveFileClass
    {
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [XmlRoot("WorldData")]
        public partial class WorldData
        {

            private string gameField;
            
            private string gameVersionField;
            
            private long dateTimeField;
            
            private int daysPastField;

            private string worldNameField;
            
            private string respawnDifficultyField;
            
            private int currentMissionField;
            
            private WorldDataStationContactData[] stationContactsField;
            
            private string researchKeyField;
            
            private string unlockedResearchHashField;
            
            private int overallIndexOfContactsField;
            
            private int worldTypeField;

            private int worldSeedField;
            
            private int bedrockLevelField;
            
            private float sunTimeField;
            
            private string roomsField;
            
            private int[] pipeNetworksField;
            
            private int[] cableNetworksField;
            
            private int[] chuteNetworksField;
            
            private string rocketShuttleNetworksField;
            
            private string spawnPointsField;
            
            private string mothershipsField;

            /// <remarks/>
            
            public string Game
            {
                get
                {
                    return this.gameField;
                }
                set
                {
                    this.gameField = value;
                }
            }

            /// <remarks/>
            
            public string GameVersion
            {
                get
                {
                    return this.gameVersionField;
                }
                set
                {
                    this.gameVersionField = value;
                }
            }

            /// <remarks/>
            
            public long DateTime
            {
                get
                {
                    return this.dateTimeField;
                }
                set
                {
                    this.dateTimeField = value;
                }
            }

            /// <remarks/>
            
            public int DaysPast
            {
                get
                {
                    return this.daysPastField;
                }
                set
                {
                    this.daysPastField = value;
                }
            }

            /// <remarks/>
            
            public string WorldName
            {
                get
                {
                    return this.worldNameField;
                }
                set
                {
                    this.worldNameField = value;
                }
            }

            /// <remarks/>
            
            public string RespawnDifficulty
            {
                get
                {
                    return this.respawnDifficultyField;
                }
                set
                {
                    this.respawnDifficultyField = value;
                }
            }

            /// <remarks/>
            
            public int CurrentMission
            {
                get
                {
                    return this.currentMissionField;
                }
                set
                {
                    this.currentMissionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("StationContactData", IsNullable = false)]
            
            public WorldDataStationContactData[] StationContacts
            {
                get
                {
                    return this.stationContactsField;
                }
                set
                {
                    this.stationContactsField = value;
                }
            }

            /// <remarks/>
            
            public string ResearchKey
            {
                get
                {
                    return this.researchKeyField;
                }
                set
                {
                    this.researchKeyField = value;
                }
            }

            /// <remarks/>
            
            public string UnlockedResearchHash
            {
                get
                {
                    return this.unlockedResearchHashField;
                }
                set
                {
                    this.unlockedResearchHashField = value;
                }
            }

            /// <remarks/>
            
            public int OverallIndexOfContacts
            {
                get
                {
                    return this.overallIndexOfContactsField;
                }
                set
                {
                    this.overallIndexOfContactsField = value;
                }
            }

            /// <remarks/>
            public int WorldType
            {
                get
                {
                    return this.worldTypeField;
                }
                set
                {
                    this.worldTypeField = value;
                }
            }

            /// <remarks/>
            public int WorldSeed
            {
                get
                {
                    return this.worldSeedField;
                }
                set
                {
                    this.worldSeedField = value;
                }
            }

            /// <remarks/>
            
            public int BedrockLevel
            {
                get
                {
                    return this.bedrockLevelField;
                }
                set
                {
                    this.bedrockLevelField = value;
                }
            }

            /// <remarks/>
            
            public float SunTime
            {
                get
                {
                    return this.sunTimeField;
                }
                set
                {
                    this.sunTimeField = value;
                }
            }

            /// <remarks/>
            
            public string Rooms
            {
                get
                {
                    return this.roomsField;
                }
                set
                {
                    this.roomsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("NetworkId", IsNullable = false)]
            
            public int[] PipeNetworks
            {
                get
                {
                    return this.pipeNetworksField;
                }
                set
                {
                    this.pipeNetworksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("NetworkId", IsNullable = false)]
            
            public int[] CableNetworks
            {
                get
                {
                    return this.cableNetworksField;
                }
                set
                {
                    this.cableNetworksField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("NetworkId", IsNullable = false)]
            
            public int[] ChuteNetworks
            {
                get
                {
                    return this.chuteNetworksField;
                }
                set
                {
                    this.chuteNetworksField = value;
                }
            }

            /// <remarks/>
            
            public string RocketShuttleNetworks
            {
                get
                {
                    return this.rocketShuttleNetworksField;
                }
                set
                {
                    this.rocketShuttleNetworksField = value;
                }
            }

            /// <remarks/>
            
            public string SpawnPoints
            {
                get
                {
                    return this.spawnPointsField;
                }
                set
                {
                    this.spawnPointsField = value;
                }
            }

            /// <remarks/>
            
            public string Motherships
            {
                get
                {
                    return this.mothershipsField;
                }
                set
                {
                    this.mothershipsField = value;
                }
            }

            /// <remarks/>
            [XmlArray("Things")]
            [XmlArrayItem("ThingSaveData", typeof(ThingSaveDataBase))]
            [XmlArrayItem("StructureSaveData", typeof(StructureSaveData))]
            [XmlArrayItem("DynamicThingSaveData", typeof(DynamicThingSaveData))]
            [XmlArrayItem("StackableSaveData", typeof(StackableSaveData))]
            [XmlArrayItem("BatteryCellSaveData", typeof(BatteryCellSaveData))]
            [XmlArrayItem("ConsumableSaveData", typeof(ConsumableSaveData))]
            
            public List<ThingSaveDataBase> Things { get; set; }

            [XmlElement("eulerAngles")]
            public EulerAnglesType EulerAngles { get; set; }

        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("WorldDataStationContactData")]
        public partial class WorldDataStationContactData
        {
            
            private AngleType angleField;
            
            private string contactNameField;
            
            private string contactTypeField;
           
            private float lifetimeField;
            
            private string tradeItemDataField;
            
            private string traderInventorySelectorField;
            
            private int overallIndexField;
            
            private float visitorCurrencyField;
            
            private int contactIDField;

            [XmlElement("Angle")]
            public AngleType Angle
            {
                get
                {
                    return this.angleField;
                }
                set
                {
                    this.angleField = value;
                }
            }

            [XmlElement("ContactName")]
            public string ContactName
            {
                get
                {
                    return this.contactNameField;
                }
                set
                {
                    this.contactNameField = value;
                }
            }

            [XmlElement("ContactType")]
            public string ContactType
            {
                get
                {
                    return this.contactTypeField;
                }
                set
                {
                    this.contactTypeField = value;
                }
            }

            [XmlElement("Lifetime")]
            public float Lifetime
            {
                get
                {
                    return this.lifetimeField;
                }
                set
                {
                    this.lifetimeField = value;
                }
            }

            [XmlElement("TradeItemData")]
            public string TradeItemData
            {
                get
                {
                    return this.tradeItemDataField;
                }
                set
                {
                    this.tradeItemDataField = value;
                }
            }

            [XmlElement("TraderInventorySelector")]
            public string TraderInventorySelector
            {
                get
                {
                    return this.traderInventorySelectorField;
                }
                set
                {
                    this.traderInventorySelectorField = value;
                }
            }

            [XmlElement("OverallIndex")]
            public int OverallIndex
            {
                get
                {
                    return this.overallIndexField;
                }
                set
                {
                    this.overallIndexField = value;
                }
            }

            [XmlElement("VisitorCurrency")]
            public float VisitorCurrency
            {
                get
                {
                    return this.visitorCurrencyField;
                }
                set
                {
                    this.visitorCurrencyField = value;
                }
            }

            [XmlElement("ContactID")]
            public int ContactID
            {
                get
                {
                    return this.contactIDField;
                }
                set
                {
                    this.contactIDField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("Angle")]
        public partial class AngleType
        {

            private float xField;

            private float yField;

            private float zField;

            /// <remarks/>
            public float x
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            /// <remarks/>
            public float y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }

            /// <remarks/>
            public float z
            {
                get
                {
                    return this.zField;
                }
                set
                {
                    this.zField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("DamageStateType")]
        public partial class DamageStateType
        {

            private float bruteField;

            private float burnField;

            private float oxygenField;

            private float hydrationField;

            private float starvationField;

            private float toxicField;

            private float radiationField;

            private float stunField;

            /// <remarks/>
            public float Brute
            {
                get
                {
                    return this.bruteField;
                }
                set
                {
                    this.bruteField = value;
                }
            }

            /// <remarks/>
            public float Burn
            {
                get
                {
                    return this.burnField;
                }
                set
                {
                    this.burnField = value;
                }
            }

            /// <remarks/>
            public float Oxygen
            {
                get
                {
                    return this.oxygenField;
                }
                set
                {
                    this.oxygenField = value;
                }
            }

            /// <remarks/>
            public float Hydration
            {
                get
                {
                    return this.hydrationField;
                }
                set
                {
                    this.hydrationField = value;
                }
            }

            /// <remarks/>
            public float Starvation
            {
                get
                {
                    return this.starvationField;
                }
                set
                {
                    this.starvationField = value;
                }
            }

            /// <remarks/>
            public float Toxic
            {
                get
                {
                    return this.toxicField;
                }
                set
                {
                    this.toxicField = value;
                }
            }

            /// <remarks/>
            public float Radiation
            {
                get
                {
                    return this.radiationField;
                }
                set
                {
                    this.radiationField = value;
                }
            }

            /// <remarks/>
            public float Stun
            {
                get
                {
                    return this.stunField;
                }
                set
                {
                    this.stunField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("WorldRotation")]
        public partial class WorldRotationType
        {

            private float xField;

            private float yField;

            private float zField;

            private float wField;

            [XmlElement("x")]
            public float x
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            [XmlElement("y")]
            public float y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }

            [XmlElement("z")]
            public float z
            {
                get
                {
                    return this.zField;
                }
                set
                {
                    this.zField = value;
                }
            }

            [XmlElement("w")]
            public float w
            {
                get
                {
                    return this.wField;
                }
                set
                {
                    this.wField = value;
                }
            }

            [XmlElement("eulerAngles")]
            public EulerAnglesType eulerAngles { get; set; }
        }


        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
       // [XmlType("eulerAngles")]
        public class EulerAnglesType
        {
            [XmlElement("x")]
            public float x { get; set; }

            [XmlElement("y")]
            public float y { get; set; }

            [XmlElement("z")]
            public float z { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("WorldPosition")]
        public partial class WorldPositionType
        {

            private float xField;

            private float yField;

            private float zField;

            [XmlElement("x")]
            public float x
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            [XmlElement("y")]
            public float y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }

            [XmlElement("z")]
            public float z
            {
                get
                {
                    return this.zField;
                }
                set
                {
                    this.zField = value;
                }
            }
        }

        /// <remarks/>
        [XmlInclude(typeof(StructureSaveData))]
        [XmlInclude(typeof(StackableSaveData))]
        [XmlInclude(typeof(DynamicThingSaveData))]
        [XmlInclude(typeof(BatteryCellSaveData))]
        [XmlInclude(typeof(ConsumableSaveData))]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("ThingSaveDataBase")]
        public abstract partial class ThingSaveDataBase
        {

            private int referenceIdField;

            private string prefabNameField;

            private string customNameField;

            private WorldPositionType worldPositionField;

            private WorldRotationType worldRotationField;

            /// <remarks/>
            public int ReferenceId
            {
                get
                {
                    return this.referenceIdField;
                }
                set
                {
                    this.referenceIdField = value;
                }
            }

            /// <remarks/>
            public string PrefabName
            {
                get
                {
                    return this.prefabNameField;
                }
                set
                {
                    this.prefabNameField = value;
                }
            }

            public string CustomNameField
            {
                get
                {
                    return this.customNameField;
                }
                set
                {
                    this.customNameField = value;
                }
            }


            /// <remarks/>
            public WorldPositionType WorldPosition
            {
                get
                {
                    return this.worldPositionField;
                }
                set
                {
                    this.worldPositionField = value;
                }
            }

            /// <remarks/>
            public WorldRotationType WorldRotation
            {
                get
                {
                    return this.worldRotationField;
                }
                set
                {
                    this.worldRotationField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("BatteryCellSaveData")]
        public partial class BatteryCellSaveData : ThingSaveDataBase
        {

            private int powerStoredField;

            /// <remarks/>
            public int PowerStored
            {
                get
                {
                    return this.powerStoredField;
                }
                set
                {
                    this.powerStoredField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("ConsumableSaveData")]
        public partial class ConsumableSaveData : ThingSaveDataBase
        {

            private int quantityField;

            /// <remarks/>
            public int Quantity
            {
                get
                {
                    return this.quantityField;
                }
                set
                {
                    this.quantityField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("DynamicThingSaveData")]
        public partial class DynamicThingSaveData : ThingSaveDataBase
        {

            private StatesTypeState[] statesField;

            private int parentReferenceIdField;

            private int parentSlotIdField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("State", IsNullable = false)]
            [XmlElement("States")]
            public StatesTypeState[] States
            {
                get
                {
                    return this.statesField;
                }
                set
                {
                    this.statesField = value;
                }
            }

            /// <remarks/>
            public int ParentReferenceId
            {
                get
                {
                    return this.parentReferenceIdField;
                }
                set
                {
                    this.parentReferenceIdField = value;
                }
            }

            /// <remarks/>
            public int ParentSlotId
            {
                get
                {
                    return this.parentSlotIdField;
                }
                set
                {
                    this.parentSlotIdField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("DoorThingSaveData")]
        public partial class DoorThingSaveData : ThingSaveDataBase
        {

            private StatesTypeState[] statesField;

            private int parentReferenceIdField;

            private int parentSlotIdField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("State", IsNullable = false)]
            [XmlElement("States")]
            public StatesTypeState[] States
            {
                get
                {
                    return this.statesField;
                }
                set
                {
                    this.statesField = value;
                }
            }

            /// <remarks/>
            public int ParentReferenceId
            {
                get
                {
                    return this.parentReferenceIdField;
                }
                set
                {
                    this.parentReferenceIdField = value;
                }
            }

            /// <remarks/>
            public int ParentSlotId
            {
                get
                {
                    return this.parentSlotIdField;
                }
                set
                {
                    this.parentSlotIdField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("StackableSaveData")]
        public class StackableSaveData : ThingSaveDataBase
        {
            [XmlElement("CustomName")]
            public string CustomName { get; set; }

            [XmlElement("IsCustomName")]
            public bool IsCustomName { get; set; }
            [XmlElement("CustomColorIndex")]
            public int CustomColorIndex { get; set; }
            [XmlElement("OwnerSteamId")]
            public long OwnerSteamId { get; set; }
            [XmlElement("Indestructable")]
            public bool Indestructable { get; set; }
            [XmlElement("DamageState")]
            public DamageState DamageState { get; set; }

            public int ParentReferenceId { get; set; }
            public int ParentSlotId { get; set; }

            public bool Dragged { get; set; }
            public int DraggedInteractionIndex { get; set; }

            public Offset DragOffset { get; set; }
            public Velocity Velocity { get; set; }
            public AngularVelocity AngularVelocity { get; set; }

            public int HealthCurrent { get; set; }
            public int Quantity { get; set; }
            public int MothershipReferenceId { get; set; }
        }

        
        
        
        
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("Position")]
        public class Position
        {
            [XmlElement("x")]
            public float x { get; set; }
            [XmlElement("y")]
            public float y { get; set; }
            [XmlElement("z")]
            public float z { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("Rotation")]
        public class Rotation
        {
            [XmlElement("x")]
            public float x { get; set; }
            [XmlElement("y")]
            public float y { get; set; }
            [XmlElement("z")]
            public float z { get; set; }
            [XmlElement("w")]
            public float w { get; set; }
            [XmlElement("eulerAngles")]
            public EulerAngles eulerAngles { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("EulerAngles")]
        public class EulerAngles
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("DamageState")]
        public class DamageState
        {
            public int Brute { get; set; }
            public int Burn { get; set; }
            public int Oxygen { get; set; }
            public int Hydration { get; set; }
            public int Starvation { get; set; }
            public int Toxic { get; set; }
            public int Radiation { get; set; }
            public int Stun { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("Offset")]
        public class Offset
        {
            [XmlElement("x")]
            public float x { get; set; }
            [XmlElement("y")]
            public float y { get; set; }
            [XmlElement("z")]
            public float z { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("Velocity")]
        public class Velocity
        {
            [XmlElement("x")]
            public float x { get; set; }
            [XmlElement("y")]
            public float y { get; set; }
            [XmlElement("z")]
            public float z { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("AngularVelocity")]
        public class AngularVelocity
        {
            [XmlElement("x")]
            public float x { get; set; }
            [XmlElement("y")]
            public float y { get; set; }
            [XmlElement("z")]
            public float z { get; set; }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("StatesTypeState")]
        public partial class StatesTypeState
        {

            private string stateNameField;

            private int stateField;

            /// <remarks/>
            public string StateName
            {
                get
                {
                    return this.stateNameField;
                }
                set
                {
                    this.stateNameField = value;
                }
            }

            /// <remarks/>
            public int State
            {
                get
                {
                    return this.stateField;
                }
                set
                {
                    this.stateField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("StructureSaveData")]
        public partial class StructureSaveData : ThingSaveDataBase
        {

            private bool isCustomNameField;

            private int customColorIndexField;

            private long ownerSteamIdField;

            private bool indestructableField;

            private DamageStateType damageStateField;

            private int currentBuildStateField;

            private int mothershipReferenceIdField;

            private bool hasSpawnedWreckageField;

            /// <remarks/>
            public bool IsCustomName
            {
                get
                {
                    return this.isCustomNameField;
                }
                set
                {
                    this.isCustomNameField = value;
                }
            }

            /// <remarks/>
            public int CustomColorIndex
            {
                get
                {
                    return this.customColorIndexField;
                }
                set
                {
                    this.customColorIndexField = value;
                }
            }

            /// <remarks/>
            public long OwnerSteamId
            {
                get
                {
                    return this.ownerSteamIdField;
                }
                set
                {
                    this.ownerSteamIdField = value;
                }
            }

            /// <remarks/>
            public bool Indestructable
            {
                get
                {
                    return this.indestructableField;
                }
                set
                {
                    this.indestructableField = value;
                }
            }

            /// <remarks/>
            public DamageStateType DamageState
            {
                get
                {
                    return this.damageStateField;
                }
                set
                {
                    this.damageStateField = value;
                }
            }

            /// <remarks/>
            public int CurrentBuildState
            {
                get
                {
                    return this.currentBuildStateField;
                }
                set
                {
                    this.currentBuildStateField = value;
                }
            }

            /// <remarks/>
            public int MothershipReferenceId
            {
                get
                {
                    return this.mothershipReferenceIdField;
                }
                set
                {
                    this.mothershipReferenceIdField = value;
                }
            }

            /// <remarks/>
            public bool HasSpawnedWreckage
            {
                get
                {
                    return this.hasSpawnedWreckageField;
                }
                set
                {
                    this.hasSpawnedWreckageField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType("WorldDataThingSaveData")]
        public partial class WorldDataThingSaveData : ThingSaveDataBase
        {
        }
    }
}
