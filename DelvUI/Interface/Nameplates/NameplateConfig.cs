﻿using DelvUI.Config;
using DelvUI.Config.Attributes;
using DelvUI.Enums;
using DelvUI.Interface.Bars;
using System;
using System.Numerics;

namespace DelvUI.Interface.GeneralElements
{
    public enum NameplatesOcclusionMode
    {
        None = 0,
        Simple = 1,
        Full
    };

    [DisableParentSettings("Strata", "Position")]
    [Section("Nameplates")]
    [SubSection("General", 0)]
    public class NameplatesGeneralConfig : MovablePluginConfigObject
    {
        public new static NameplatesGeneralConfig DefaultConfig() => new NameplatesGeneralConfig();

        [Combo("Occlusion Mode", new string[] { "Disabled", "Simple", "Full" }, help = "This controls wheter you'll see nameplates through walls and objects.\n\nDisabled: Nameplates will always be seen for units in range.\nSimple: Uses simple calculations to check if a nameplate is being covered by walls or objects. Use this for better performance.\nFull: Uses more complex calculations to check if a nameplate is being covered by walls or objects. Use this for better results.")]
        [Order(10)]
        public NameplatesOcclusionMode OcclusionMode = NameplatesOcclusionMode.Full;
    }

    [DisableParentSettings("HideWhenInactive")]
    [Section("Nameplates")]
    [SubSection("Player", 0)]
    public class PlayerNameplateConfig : NameplateWithPlayerBarConfig
    {
        public PlayerNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplatePlayerBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig, barConfig)
        {
        }

        public new static PlayerNameplateConfig DefaultConfig()
        {
            return NameplatesHelper.GetNameplateWithPlayerBarConfig<PlayerNameplateConfig>(
                0xFFD0E5E0, 
                0xFF30444A,
                HUDConstants.DefaultPlayerNameplateBarSize
            );
        }
    }

    [DisableParentSettings("HideWhenInactive")]
    [Section("Nameplates")]
    [SubSection("Party Members", 0)]
    public class PartyMembersNameplateConfig : NameplateWithPlayerBarConfig
    {
        public PartyMembersNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplatePlayerBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig, barConfig)
        {
        }

        public new static PartyMembersNameplateConfig DefaultConfig()
        {
            PartyMembersNameplateConfig config = NameplatesHelper.GetNameplateWithPlayerBarConfig<PartyMembersNameplateConfig>(
                0xFFD0E5E0, 
                0xFF30444A,
                HUDConstants.DefaultPlayerNameplateBarSize
            );

            config.BarConfig.UseRoleColor = true;
            config.NameLabelConfig.UseRoleColor = true;
            config.TitleLabelConfig.UseRoleColor = true;
            return config;
        }
    }

    [DisableParentSettings("HideWhenInactive")]
    [Section("Nameplates")]
    [SubSection("Alliance Members", 0)]
    public class AllianceMembersNameplateConfig : NameplateWithPlayerBarConfig
    {
        public AllianceMembersNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplatePlayerBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig, barConfig)
        {
        }

        public new static AllianceMembersNameplateConfig DefaultConfig()
        {
            return NameplatesHelper.GetNameplateWithPlayerBarConfig<AllianceMembersNameplateConfig>(
                0xFF99BE46, 
                0xFF3D4C1C,
                HUDConstants.DefaultPlayerNameplateBarSize
            );
        }
    }

    [DisableParentSettings("HideWhenInactive")]
    [Section("Nameplates")]
    [SubSection("Friends", 0)]
    public class FriendPlayerNameplateConfig : NameplateWithPlayerBarConfig
    {
        public FriendPlayerNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplatePlayerBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig, barConfig)
        {
        }

        public new static FriendPlayerNameplateConfig DefaultConfig()
        {
            return NameplatesHelper.GetNameplateWithPlayerBarConfig<FriendPlayerNameplateConfig>(
                0xFFEB6211,
                0xFF4A2008,
                HUDConstants.DefaultPlayerNameplateBarSize
            );
        }
    }

    [DisableParentSettings("HideWhenInactive")]
    [Section("Nameplates")]
    [SubSection("Other Players", 0)]
    public class OtherPlayerNameplateConfig : NameplateWithPlayerBarConfig
    {
        public OtherPlayerNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplatePlayerBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig, barConfig)
        {
        }

        public new static OtherPlayerNameplateConfig DefaultConfig()
        {
            return NameplatesHelper.GetNameplateWithPlayerBarConfig<OtherPlayerNameplateConfig>(
                0xFF91BBD8,
                0xFF33434E,
                HUDConstants.DefaultPlayerNameplateBarSize
            );
        }
    }

    [DisableParentSettings("HideWhenInactive")]
    [Section("Nameplates")]
    [SubSection("Pets", 0)]
    public class PetNameplateConfig : NameplateWithNPCBarConfig
    {
        public PetNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplatePlayerBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig, barConfig)
        {
        }

        public new static PetNameplateConfig DefaultConfig()
        {
            PetNameplateConfig config = NameplatesHelper.GetNameplateWithPlayerBarConfig<PetNameplateConfig>(
                0xFFD1E5C8,
                0xFF2A2F28,
                HUDConstants.DefaultPlayerNameplateBarSize
            );
            config.OnlyShowWhenTargeted = true;
            config.SwapLabelsWhenNeeded = false;
            config.NameLabelConfig.Text = "Lv[level] [name]";
            config.NameLabelConfig.FontID = FontsConfig.DefaultSmallFontKey;
            config.TitleLabelConfig.FontID = FontsConfig.DefaultSmallFontKey;

            return config;
        }
    }

    [DisableParentSettings("HideWhenInactive", "SwapLabelsWhenNeeded")]
    [Section("Nameplates")]
    [SubSection("NPCs", 0)]
    public class NonCombatNPCNameplateConfig : NameplateConfig
    {
        public NonCombatNPCNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig)
            : base(position, nameLabel, titleLabelConfig)
        {
        }

        public new static NonCombatNPCNameplateConfig DefaultConfig()
        {
            NonCombatNPCNameplateConfig config = NameplatesHelper.GetNameplateConfig<NonCombatNPCNameplateConfig>(0xFFD1E5C8, 0xFF3A4b1E);
            config.SwapLabelsWhenNeeded = false;
            config.NameLabelConfig.Position = new Vector2(0, -20);
            config.TitleLabelConfig.Position = Vector2.Zero;

            return config;
        }
    }

    [DisableParentSettings("HideWhenInactive", "SwapLabelsWhenNeeded")]
    [Section("Nameplates")]
    [SubSection("Minions", 0)]
    public class MinionNPCNameplateConfig : NameplateConfig
    {
        public MinionNPCNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig)
            : base(position, nameLabel, titleLabelConfig)
        {
        }

        public new static MinionNPCNameplateConfig DefaultConfig()
        {
            MinionNPCNameplateConfig config = NameplatesHelper.GetNameplateConfig<MinionNPCNameplateConfig>(0xFFFFFFFF, 0xFF000000);
            config.OnlyShowWhenTargeted = true;
            config.SwapLabelsWhenNeeded = false;
            config.NameLabelConfig.Position = new Vector2(0, -17);
            config.NameLabelConfig.FontID = FontsConfig.DefaultSmallFontKey;
            config.TitleLabelConfig.Position = new Vector2(0, 0);
            config.TitleLabelConfig.FontID = FontsConfig.DefaultSmallFontKey;

            return config;
        }
    }

    [DisableParentSettings("HideWhenInactive", "SwapLabelsWhenNeeded")]
    [Section("Nameplates")]
    [SubSection("Objects", 0)]
    public class ObjectsNameplateConfig : NameplateConfig
    {
        public ObjectsNameplateConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig)
            : base(position, nameLabel, titleLabelConfig)
        {
        }
    
        public new static ObjectsNameplateConfig DefaultConfig()
        {
            ObjectsNameplateConfig config = NameplatesHelper.GetNameplateConfig<ObjectsNameplateConfig>(0xFFFFFFFF, 0xFF000000);
            config.SwapLabelsWhenNeeded = false;

            return config;
        }
    }

    public class NameplateConfig : MovablePluginConfigObject
    {
        [Checkbox("Only show when targeted")]
        [Order(1)]
        public bool OnlyShowWhenTargeted = false;

        [Checkbox("Swap Name and Title labels when needed", spacing = true, help = "This will swap the contents of these labels depending on if the title goes before or after the name of a player.")]
        [Order(20)]
        public bool SwapLabelsWhenNeeded = true;

        [NestedConfig("Name Label", 21)]
        public EditableLabelConfig NameLabelConfig = null!;

        [NestedConfig("Title Label", 22)]
        public EditableNonFormattableLabelConfig TitleLabelConfig = null!;

        [NestedConfig("Change Alpha Based on Range", 145)]
        public UnitFramesRangeConfig RangeConfig = new();

        [NestedConfig("Visibility", 200)]
        public VisibilityConfig VisibilityConfig = new VisibilityConfig();

        public NameplateConfig(Vector2 position, EditableLabelConfig nameLabelConfig, EditableNonFormattableLabelConfig titleLabelConfig)
            : base()
        {
            Position = position;
            NameLabelConfig = nameLabelConfig;
            TitleLabelConfig = titleLabelConfig;
        }

        public NameplateConfig() : base() { } // don't remove
    }

    public interface NameplateWithBarConfig
    {
        public NameplateBarConfig GetBarConfig();
    }

    public class NameplateWithNPCBarConfig : NameplateConfig, NameplateWithBarConfig
    {
        [NestedConfig("Health Bar", 40)]
        public NameplateBarConfig BarConfig = null!;

        public NameplateBarConfig GetBarConfig() => BarConfig;

        public NameplateWithNPCBarConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplateBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig)
        {
            BarConfig = barConfig;
        }

        public NameplateWithNPCBarConfig() : base() { } // don't remove
    }

    public class NameplateWithPlayerBarConfig : NameplateConfig, NameplateWithBarConfig
    {
        [NestedConfig("Health Bar", 40)]
        public NameplatePlayerBarConfig BarConfig = null!;

        [NestedConfig("Role/Job Icon", 50)]
        public NameplateRoleJobIconConfig RoleIconConfig = new NameplateRoleJobIconConfig(
            new Vector2(-5, 0),
            new Vector2(30, 30),
            DrawAnchor.Right,
            DrawAnchor.Left
        );

        [NestedConfig("Player State Icon", 55)]
        public NameplateIconConfig StateIconConfig = new NameplateIconConfig(
            new Vector2(5, 0),
            new Vector2(30, 30),
            DrawAnchor.Left,
            DrawAnchor.Right
        );

        public NameplateBarConfig GetBarConfig() => BarConfig;

        public NameplateWithPlayerBarConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplatePlayerBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig)
        {
            BarConfig = barConfig;
        }

        public NameplateWithPlayerBarConfig() : base() { } // don't remove
    }

    public class NameplateWithEnemyBarConfig : NameplateConfig, NameplateWithBarConfig
    {
        [NestedConfig("Health Bar", 40)]
        public NameplateEnemyBarConfig BarConfig = null!;

        public NameplateBarConfig GetBarConfig() => BarConfig;

        public NameplateWithEnemyBarConfig(
            Vector2 position,
            EditableLabelConfig nameLabel,
            EditableNonFormattableLabelConfig titleLabelConfig,
            NameplateEnemyBarConfig barConfig)
            : base(position, nameLabel, titleLabelConfig)
        {
            BarConfig = barConfig;
        }

        public NameplateWithEnemyBarConfig() : base() { } // don't remove
    }

    [DisableParentSettings("HideWhenInactive")]
    public class NameplateBarConfig : BarConfig
    {
        [Checkbox("Only Show when not at full Health")]
        [Order(1)]
        public bool OnlyShowWhenNotFull = true;

        [NestedConfig("Color Based On Health Value", 50, collapsingHeader = false)]
        public ColorByHealthValueConfig ColorByHealth = new ColorByHealthValueConfig();

        [Checkbox("Hide Health if Possible", spacing = true, help = "This will hide any label that has a health tag if the character doesn't have health (ie minions, friendly npcs, etc)")]
        [Order(121)]
        public bool HideHealthIfPossible = true;

        [NestedConfig("Left Text", 125)]
        public EditableLabelConfig LeftLabelConfig = null!;

        [NestedConfig("Right Text", 130)]
        public EditableLabelConfig RightLabelConfig = null!;

        [NestedConfig("Optional Text", 131)]
        public EditableLabelConfig OptionalLabelConfig = null!;

        [NestedConfig("Shields", 140)]
        public ShieldConfig ShieldConfig = new ShieldConfig();

        [NestedConfig("Custom Mouseover Area", 150)]
        public MouseoverAreaConfig MouseoverAreaConfig = new MouseoverAreaConfig();

        public NameplateBarConfig(Vector2 position, Vector2 size, EditableLabelConfig leftLabelConfig, EditableLabelConfig rightLabelConfig, EditableLabelConfig optionalLabelConfig)
            : base(position, size, new PluginConfigColor(new(40f / 255f, 40f / 255f, 40f / 255f, 100f / 100f)))
        {
            Position = position;
            Size = size;
            LeftLabelConfig = leftLabelConfig;
            RightLabelConfig = rightLabelConfig;
            OptionalLabelConfig = optionalLabelConfig;
            BackgroundColor = new PluginConfigColor(new(0f / 255f, 0f / 255f, 0f / 255f, 100f / 100f));
            ColorByHealth.Enabled = false;
            MouseoverAreaConfig.Enabled = false;
        }

        public bool IsVisible(uint hp, uint maxHp)
        {
            return Enabled && (!OnlyShowWhenNotFull || hp < maxHp);
        }

        public NameplateBarConfig() : base(Vector2.Zero, Vector2.Zero, new(Vector4.Zero)) { } // don't remove
    }

    public class NameplatePlayerBarConfig : NameplateBarConfig
    {
        [Checkbox("Use Job Color", spacing = true)]
        [Order(45)]
        public bool UseJobColor = false;

        [Checkbox("Use Role Color")]
        [Order(46)]
        public bool UseRoleColor = false;

        [Checkbox("Job Color As Background Color", spacing = true)]
        [Order(50)]
        public bool UseJobColorAsBackgroundColor = false;

        [Checkbox("Role Color As Background Color")]
        [Order(51)]
        public bool UseRoleColorAsBackgroundColor = false;

        public NameplatePlayerBarConfig(Vector2 position, Vector2 size, EditableLabelConfig leftLabelConfig, EditableLabelConfig rightLabelConfig, EditableLabelConfig optionalLabelConfig)
            : base(position, size, leftLabelConfig, rightLabelConfig, optionalLabelConfig)
        {
        }
    }

    public class NameplateEnemyBarConfig : NameplateBarConfig
    {
        public NameplateEnemyBarConfig(Vector2 position, Vector2 size, EditableLabelConfig leftLabelConfig, EditableLabelConfig rightLabelConfig, EditableLabelConfig optionalLabelConfig)
            : base(position, size, leftLabelConfig, rightLabelConfig, optionalLabelConfig)
        {

        }
    }

    [Exportable(false)]
    public class NameplateRangeConfig : PluginConfigObject
    {
        [DragInt("Fade start range (yalms)", min = 1, max = 500)]
        [Order(5)]
        public int StartRange = 30;

        [DragInt("Fade end range (yalms)", min = 1, max = 500)]
        [Order(10)]
        public int EndRange = 50;

        public float AlphaForDistance(int distance, float alpha = 100f)
        {
            distance = distance - StartRange;
            if (!Enabled || distance <= 0)
            {
                return 100f;
            }

            float diff = EndRange - distance;
            if (diff <= 0)
            {
                return 0f;
            }

            return diff * 100f / (EndRange - StartRange);
        }
    }

    internal static class NameplatesHelper
    {
        internal static T GetNameplateConfig<T>(uint bgColor, uint borderColor) where T : NameplateConfig
        {
            EditableLabelConfig nameLabelConfig = new EditableLabelConfig(new Vector2(0, 0), "[name]", DrawAnchor.Top, DrawAnchor.Bottom)
            {
                Color = PluginConfigColor.FromHex(bgColor),
                OutlineColor = PluginConfigColor.FromHex(borderColor),
                FontID = FontsConfig.DefaultMediumFontKey
            };

            EditableNonFormattableLabelConfig titleLabelConfig = new EditableNonFormattableLabelConfig(new Vector2(0, -25), "<[title]>", DrawAnchor.Top, DrawAnchor.Bottom)
            {
                Color = PluginConfigColor.FromHex(bgColor),
                OutlineColor = PluginConfigColor.FromHex(borderColor),
                FontID = FontsConfig.DefaultMediumFontKey
            };

            return (T)Activator.CreateInstance(typeof(T), Vector2.Zero, nameLabelConfig, titleLabelConfig)!;
        }

        internal static T GetNameplateWithPlayerBarConfig<T>(uint bgColor, uint borderColor, Vector2 barSize) where T : NameplateConfig
        {
            EditableLabelConfig leftLabelConfig = new EditableLabelConfig(new Vector2(5, 0), "Lv[level]", DrawAnchor.Left, DrawAnchor.Left)
            {
                Enabled = false,
                FontID = FontsConfig.DefaultMediumFontKey
            };
            EditableLabelConfig rightLabelConfig = new EditableLabelConfig(new Vector2(-5, 0), "[health:current-short]", DrawAnchor.Right, DrawAnchor.Right)
            {
                Enabled = false,
                FontID = FontsConfig.DefaultMediumFontKey
            };
            EditableLabelConfig optionalLabelConfig = new EditableLabelConfig(new Vector2(0, 0), "", DrawAnchor.Center, DrawAnchor.Center)
            {
                Enabled = false,
                FontID = FontsConfig.DefaultMediumFontKey
            };
            NameplatePlayerBarConfig barConfig = new NameplatePlayerBarConfig(new Vector2(0, -5), barSize, leftLabelConfig, rightLabelConfig, optionalLabelConfig)
            {
                FillColor = PluginConfigColor.FromHex(bgColor),
                BackgroundColor = PluginConfigColor.FromHex(0xAA000000)
            };

            EditableLabelConfig nameLabelConfig = new EditableLabelConfig(new Vector2(0, -20), "[name]", DrawAnchor.Top, DrawAnchor.Bottom)
            {
                Color = PluginConfigColor.FromHex(bgColor),
                OutlineColor = PluginConfigColor.FromHex(borderColor),
                FontID = FontsConfig.DefaultMediumFontKey
            };
            EditableNonFormattableLabelConfig titleLabelConfig = new EditableNonFormattableLabelConfig(new Vector2(0, 0), "<[title]>", DrawAnchor.Top, DrawAnchor.Bottom)
            {
                Color = PluginConfigColor.FromHex(bgColor),
                OutlineColor = PluginConfigColor.FromHex(borderColor),
                FontID = FontsConfig.DefaultMediumFontKey
            };

            return (T)Activator.CreateInstance(typeof(T), Vector2.Zero, nameLabelConfig, titleLabelConfig, barConfig)!;
        }
    }
}
